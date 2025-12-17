using System;

namespace ConsoleApp2.Models
{
    public interface IItem
    {
        int Id { get; set; }
        string Title { get; }
        string Author { get; }
        int Year { get; }
        bool IsBorrowed { get; set; }
        string BorrowedBy { get; set; }

        IItem Clone();
        string GetBasicDisplay();
    }
}
