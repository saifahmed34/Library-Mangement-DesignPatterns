using ConsoleApp2.Models;

namespace ConsoleApp2.Factories
{
    // Abstract Factory concrete for magazines
    public class MagazineFactory : IItemFactory
    {
        public IItem CreateItem(string title, string author, int year) => new Magazine(title, author, year);
    }
}
