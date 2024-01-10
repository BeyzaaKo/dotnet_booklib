using System.Net.Http;
using System.Threading.Tasks;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ASP.NETCoreIdentityCustom.Views.Discover
{
    public class GetBookInfoModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ISBN { get; set; }

        public BookModel BookInfo { get; set; } = new BookModel(); // BookModel örneği oluşturuldu

        public async Task OnGetAsync(string isbn)
        {
            try
            {
                if (!string.IsNullOrEmpty(isbn))
                {
                    var apiKey = "AIzaSyCyzDggZ-_ChpGRDcY9UQPh44tkIzOFyQU";
                    var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{ISBN}&key={apiKey}";

                    var client = new HttpClient();
                    var response = await client.GetStringAsync(apiUrl);

                    BookInfo = ParseBookInfo(response);
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
            var bookModel = new BookModel();

            // JSON verisini çözümle (Newtonsoft.Json paketi bu işlem için kullanılabilir)
            dynamic jsonData = JsonConvert.DeserializeObject(json);

            // Kitap bilgilerini doldur
            if (jsonData.totalItems > 0)
            {
                var volumeInfo = jsonData.items[0].volumeInfo;

                bookModel.Title = volumeInfo.title;
                bookModel.Author = string.Join(", ", volumeInfo.authors);
                bookModel.Description = volumeInfo.description;
                bookModel.PublishedDate = volumeInfo.publishedDate;
                bookModel.ThumbnailUrl = volumeInfo.imageLinks?.thumbnail;
                bookModel.ISBN = volumeInfo.industryIdentifiers[0]?.identifier;
            }

            return bookModel;
        }


        /*public async Task<BookModel> GetBookInfo(string isbn)
        {
            var apiKey = "AIzaSyAsx4hsKQC0U_xkB3ny7_f2jfmjAnUA3RY";
            var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";

            var client = new HttpClient();
            var response = await client.GetStringAsync(apiUrl);

            return ParseBookInfo(response);
        }*/
    }
}
