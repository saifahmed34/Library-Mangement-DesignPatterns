using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.Core;
using ConsoleApp2.Models;

namespace ConsoleApp2.Facade
{
    // Facade: simpler API for library operations
    // Hides complexity of Library class
    //Provides a simplified interface to a complex subsystem.
    //The client does not interact directly
    //Easier to change internal logic later
    public class LibraryFacade
    {
        private readonly Library _lib;

        public LibraryFacade(Library lib)
        {
            _lib = lib;
        }

        public IEnumerable<IItem> ListAllItems() => _lib.Items.OrderBy(i => i.Id);

        public IEnumerable<IItem> SearchByTitle(string q) => _lib.Items.Where(i => i.Title.Contains(q, System.StringComparison.OrdinalIgnoreCase));

        public IItem? GetItemById(int id) => _lib.GetById(id);

        public bool BorrowItem(int id, string member)
        {
            var it = _lib.GetById(id);
            if (it == null || it.IsBorrowed) return false;
            it.IsBorrowed = true;
            it.BorrowedBy = member;
            return _lib.Update(it);
        }

        public bool ReturnItem(int id)
        {
            var it = _lib.GetById(id);
            if (it == null || !it.IsBorrowed) return false;
            it.IsBorrowed = false;
            it.BorrowedBy = string.Empty;
            return _lib.Update(it);
        }

        public bool AddItem(IItem item)
        {
            _lib.Add(item);
            return true;
        }
    }
}
