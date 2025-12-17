using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.Models;

namespace ConsoleApp2.Core
{
    //Singleton:
    //Used this to make sure there is only one instance of Library throughout the application.
    public sealed class Library
    {
        private static readonly Library _instance = new Library();
        public static Library Instance => _instance;

        private readonly List<IItem> _items = new();
        private int _nextId = 1;

        private Library() { }

        public IEnumerable<IItem> Items => _items.Select(i => i.Clone());

        public IItem? GetById(int id) => _items.FirstOrDefault(i => i.Id == id)?.Clone();

        public IItem Add(IItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item.Clone();
        }

        public bool Remove(int id)
        {
            var it = _items.FirstOrDefault(i => i.Id == id);
            if (it == null) return false;
            _items.Remove(it);
            return true;
        }

        public bool Update(IItem updated)
        {
            var idx = _items.FindIndex(i => i.Id == updated.Id);
            if (idx < 0) return false;
            _items[idx] = updated;
            return true;
        }
    }
}
