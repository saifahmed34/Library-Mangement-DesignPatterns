using Design_Patterns.Models;
using Design_Patterns.Repositories.Interfaces;

namespace Design_Patterns.Repositories.Implementations
{
    internal class BookImplement : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return book;

        }

        public void Updatebook(Book Book)
        {
            var book = books.FirstOrDefault(x => x.Id == Book.Id);
            if (book != null)
            {
                book.Name = Book.Name;
                book.Description = Book.Description;
                book.Author = Book.Author;
                book.State = Book.State;

            }
        }

    }
}
