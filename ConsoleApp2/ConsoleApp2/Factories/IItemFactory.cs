using ConsoleApp2.Models;

namespace ConsoleApp2.Factories
{
    public interface IItemFactory
    {
        IItem CreateItem(string title, string author, int year);
    }
}
