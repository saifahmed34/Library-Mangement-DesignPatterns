using Design_Patterns.Models;

namespace Design_Patterns.Repositories.Interfaces
{
    internal interface IBookRepository
    {
        public void AddBook(Book book);
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void Updatebook(Book book);
    }
}
