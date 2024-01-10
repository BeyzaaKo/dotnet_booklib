using ASP.NETCoreIdentityCustom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ASP.NETCoreIdentityCustom.Views.RoleViews
{
    public class DiscoverModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ISBN { get; set; }

        public BookModel BookInfo { get; set; }

        public async Task OnGetAsync(string isbn)
        {
            try
            {
                if (!string.IsNullOrEmpty(isbn))
                {
                    var apiKey = "AIzaSyCyzDggZ-_ChpGRDcY9UQPh44tkIzOFyQU";
                    var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";

                    using (var client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(apiUrl);
                        BookInfo = ParseBookInfo(response);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or print the exception details for debugging
                Console.WriteLine(ex.ToString());
                throw; // Re-throw the exception
            }
        }

        private BookModel ParseBookInfo(string json)
        {
            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

                if (apiResponse?.Items != null && apiResponse.Items.Any())
                {
                    var volumeInfo = apiResponse.Items.First().VolumeInfo;

                    var bookInfo = new BookModel
                    {
                        Title = volumeInfo.Title,
                        Author = volumeInfo.Author != null && volumeInfo.Author.Authors != null
                            ? string.Join(", ", volumeInfo.Author.Authors)
                            : null,
                        PublishedDate = volumeInfo.PublishedDate,
                        Description = volumeInfo.Description,
                        ISBN = volumeInfo.ISBN,
                        ThumbnailUrl = volumeInfo.ThumbnailUrl
                        // Diğer özellikleri ekleyin...
                    };

                    return bookInfo;
                }
            }
            catch (Exception ex)
            {
                // JSON çözme hatası
                Console.WriteLine($"JSON çözme hatası: {ex}");
            }

            return null;
        }

        // JSON verisi için gerekli sınıfları tanımlayalım
        public class ApiResponse
        {
            public List<Item> Items { get; set; }
        }

        public class Item
        {
            public VolumeInfo VolumeInfo { get; set; }
        }

        public class VolumeInfo
        {
            public string Title { get; set; }
            public AuthorInfo Author { get; set; }
            public string Description { get; set; }
            public string PublishedDate { get; set; }
            public string ISBN { get; set; }
            public string ThumbnailUrl { get; set; }
        }

        public class AuthorInfo
        {
            public List<string> Authors { get; set; }
        }

        public void OnGet()
        {
            // Bu metot, sayfa yüklendiğinde çalışan bir metottur.
            // Örneğin, sayfanın ilk yüklendiğinde yapılacak bazı işlemleri buraya ekleyebilirsiniz.
        }
    }
}
