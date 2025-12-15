namespace Design_Patterns.Models
{
    internal class Book
    {
        public enum BookState
        {
            Available,
            Borrowed
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public BookState State { get; set; } = BookState.Available;
        public int? BorrowedByMemberId { get; set; }
    }
}
