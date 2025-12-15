using Design_Patterns.Models;
using Design_Patterns.Repositories.Implementations.Facade;
using Design_Patterns.Repositories.Implementations.Factory;
using Design_Patterns.Repositories.Interfaces.Factory;

class Program
{
    static void Main()
    {
        Member currentUser = new Member { Id = 1, Name = "Alice", IsAdmin = true };
        IRepositoryFactory factory = new RepositoryFactory();
        LibraryFacade library = new LibraryFacade(factory, currentUser);

        while (true)
        {
            Console.WriteLine("\n=== Library Menu ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Add Member");
            Console.WriteLine("4. List Members");
            Console.WriteLine("5. Borrow Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Book Id: ");
                    int bid = int.Parse(Console.ReadLine());

                    Console.Write("Book Name: ");
                    string bname = Console.ReadLine();

                    Console.Write("Author: ");
                    string author = Console.ReadLine();

                    library.AddBook(new Book { Id = bid, Name = bname, Author = author });
                    break;

                case "2":
                    Console.Clear();
                    library.ListAllBooks();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Member Id: "); int mid = int.Parse(Console.ReadLine());
                    Console.Write("Member Name: "); string mname = Console.ReadLine();
                    library.AddMember(new Member { Id = mid, Name = mname });
                    break;

                case "4":
                    Console.Clear();
                    library.ListAllMembers();
                    break;

                case "5":
                    Console.Clear();
                    Console.Write("Member Id: "); int borrowMid = int.Parse(Console.ReadLine());
                    Console.Write("Book Id: "); int borrowBid = int.Parse(Console.ReadLine());
                    library.BorrowBook(borrowMid, borrowBid);
                    break;

                case "6":
                    Console.Clear();
                    Console.Write("Member Id: "); int returnMid = int.Parse(Console.ReadLine());
                    Console.Write("Book Id: "); int returnBid = int.Parse(Console.ReadLine());
                    library.ReturnBook(returnMid, returnBid);
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
