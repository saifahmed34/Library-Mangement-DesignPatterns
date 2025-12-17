using ConsoleApp2.Facade;
using ConsoleApp2.Models;

namespace ConsoleApp2.Proxies
{
    // Proxy: simple auth check for admin actions

    //Controls access to another object.
    public class LibraryProxy
    {
        private readonly LibraryFacade _facade;
        private const string AdminPassword = "admin"; // simple password for testing

        public LibraryProxy(LibraryFacade facade)
        {
            _facade = facade;
        }

        public bool AddBook(IItem item)
        {
            // open add without auth (for demo internal use)
            return _facade.AddItem(item);
        }

        public bool AddBookWithPassword(IItem item, string password)
        {
            if (password != AdminPassword) return false;
            return _facade.AddItem(item);
        }
    }
}
