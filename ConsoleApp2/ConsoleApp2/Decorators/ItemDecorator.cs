using ConsoleApp2.Models;

namespace ConsoleApp2.Decorators
{
    // Decorator base
    public abstract class ItemDecorator : IItem
    {
        protected readonly IItem _inner;

        protected ItemDecorator(IItem inner)
        {
            _inner = inner;
        }

        public virtual int Id { get => _inner.Id; set => _inner.Id = value; }
        public virtual string Title => _inner.Title;
        public virtual string Author => _inner.Author;
        public virtual int Year => _inner.Year;
        public virtual bool IsBorrowed { get => _inner.IsBorrowed; set => _inner.IsBorrowed = value; }
        public virtual string BorrowedBy { get => _inner.BorrowedBy; set => _inner.BorrowedBy = value; }

        public virtual IItem Clone() => _inner.Clone();

        public virtual string GetBasicDisplay() => _inner.GetBasicDisplay();
    }
}
