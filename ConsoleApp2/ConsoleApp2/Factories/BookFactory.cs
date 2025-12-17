using ConsoleApp2.Models;

namespace ConsoleApp2.Factories
{
    // Abstract Factory concrete for books
    public class BookFactory : IItemFactory
    {
        public IItem CreateItem(string title, string author, int year) => new Book(title, author, year);
    }
}
