/*Google Books API'yi kullanarak kitap bilgilerini çeken bir GetBookInfo metodu ekledik.
Bu metot, API yanıtını parse etmek için ParseBookInfo metodunu kullanıyor ve 
sonuç olarak bir BookModel nesnesi döndürüyor.*/

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ASP.NETCoreIdentityCustom.Models; // BookModel'ı içe aktar

public class DiscoverController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscoverController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> GetBookInfo(string isbn)
    {
        var apiKey = "AIzaSyAsx4hsKQC0U_xkB3ny7_f2jfmjAnUA3RY";
        var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync(apiUrl);

        // Handle the response (parse JSON, etc.) and update the view accordingly.
        var bookModel = ParseBookInfo(response);

        return View(bookModel);
    }
    private BookModel ParseBookInfo(string apiResponse)
    {
        var bookModel = JsonConvert.DeserializeObject<BookModel>(apiResponse);
        return bookModel;
    }
}
