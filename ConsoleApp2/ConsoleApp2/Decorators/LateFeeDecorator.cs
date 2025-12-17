using System;
using ConsoleApp2.Models;

namespace ConsoleApp2.Decorators
{
    // Decorator: compute a fake late fee for display
    //Adds new behavior to an object at runtime
    public class LateFeeDecorator : ItemDecorator
    {
        public LateFeeDecorator(IItem inner) : base(inner) { }

        public string GetDisplay()
        {
            var baseLine = GetBasicDisplay();
            if (!IsBorrowed) return baseLine + "\nStatus: Available";

            // fake calculation: fee based on year difference
            var years = Math.Max(0, DateTime.Now.Year - Year);
            var fee = Math.Round(years * 0.5m, 2);
            return baseLine + $"\nStatus: Borrowed by {BorrowedBy}\nEstimated late-fee (demo): ${fee}";
        }
    }
}
