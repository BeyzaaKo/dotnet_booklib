//Kitapları ve kitap ayrıntılarını göstermek için kullanılacak olan controller.

using ASP.NETCoreIdentityCustom.Models;
using ASP.NETCoreIdentityCustom.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP.NETCoreIdentityCustom.Controllers
{ 
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

    }
}