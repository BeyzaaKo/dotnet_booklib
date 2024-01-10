using ASP.NETCoreIdentityCustom.Models;

namespace ASP.NETCoreIdentityCustom.Repositories
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();

        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();
        }

        //böyle elle almak istemiyorum, api ile çekmek veya database oluşturmak istiyorum
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "Normal People", Author = "Sally Rooney", Description="This section will be description of book."},
                new BookModel() { Id = 2, Title = "The Midnight Library", Author = "Matt Haig", Description="This section will be description of book."},
                new BookModel() { Id = 3, Title = "Atomic Habits", Author = "James Clear", Description="This section will be description of book."},
                new BookModel() { Id = 4, Title = "Animal Farm", Author = "George Orwell", Description="This section will be description of book."},
                new BookModel() { Id = 5, Title = "The Secret History", Author = "Donna Tartt", Description="This section will be description of book."},
            };
        }
    }
}
