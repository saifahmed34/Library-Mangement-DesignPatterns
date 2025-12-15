using Design_Patterns.Models;
using Design_Patterns.Repositories.Implementations.Proxy;
using Design_Patterns.Repositories.Interfaces;
using Design_Patterns.Repositories.Interfaces.Factory;
using static Design_Patterns.Models.Book;

namespace Design_Patterns.Repositories.Implementations.Facade
{
    internal class LibraryFacade
    {
        private IBookRepository bookRepo;
        private IMemberRepository memberRepo;

        public LibraryFacade(IRepositoryFactory factory, Member currentUser)
        {
            bookRepo = factory.CreateBookRepository();
            IMemberRepository realMemberRepo = factory.CreateMemberRepository();
            memberRepo = new MemberRepoProxy(realMemberRepo, currentUser); // wrap with proxy
        }

        public void AddingBook(Book book)
        {
            bookRepo.AddBook(book);
            Console.WriteLine("Book added!");
        }

        public void AddingMember(Member member)
        {
            memberRepo.AddMember(member); // Proxy handles admin check
        }

        public void ListAllBooks()
        {
            var books = bookRepo.GetAllBooks();
            Console.WriteLine("\nAll Books:");
            foreach (var b in books)
                Console.WriteLine($"Id: {b.Id}, Name: {b.Name}, Author: {b.Author}, State: {b.State}");
        }

        public void ListAllMembers()
        {
            var members = memberRepo.GetAllMembers();
            Console.WriteLine("\nAll Members:");
            foreach (var m in members)
                Console.WriteLine($"Id: {m.Id}, Name: {m.Name}");
        }

        public void BorrowBook(int memberId, int bookId)
        {
            var book = bookRepo.GetBookById(bookId);
            var member = memberRepo.GetMemberById(memberId);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }
            if (member == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }
            if (book.State == BookState.Borrowed)
            {
                Console.WriteLine("Book is already borrowed!");
                return;
            }

            book.State = BookState.Borrowed;
            book.BorrowedByMemberId = memberId;
            Console.WriteLine($"{member.Name} successfully borrowed '{book.Name}'");
        }

        public void ReturnBook(int memberId, int bookId)
        {
            var book = bookRepo.GetBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }
            if (book.State == BookState.Available || book.BorrowedByMemberId != memberId)
            {
                Console.WriteLine("This book was not borrowed by this member!");
                return;
            }

            book.State = BookState.Available;
            book.BorrowedByMemberId = null;
            Console.WriteLine($"Book '{book.Name}' returned successfully!");
        }
    }


}

