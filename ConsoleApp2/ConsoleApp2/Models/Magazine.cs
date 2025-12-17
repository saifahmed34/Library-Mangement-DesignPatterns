using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Models
{
    public class Magazine : IItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Title")]
        public string Title { get; init; }

        [Required]
        [StringLength(100)]
        public string Author { get; init; }

        [Range(1000, 9999)]
        public int Year { get; init; }

        public bool IsBorrowed { get; set; }

        [Display(Name = "Borrowed By")]
        public string BorrowedBy { get; set; } = string.Empty;

        public Magazine(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public IItem Clone() => new Magazine(Title, Author, Year)
        {
            Id = Id,
            IsBorrowed = IsBorrowed,
            BorrowedBy = BorrowedBy
        };

        public string GetBasicDisplay() => $"[{Id}] Magazine: {Title} ({Year}) {(IsBorrowed ? $"- Borrowed by {BorrowedBy}" : "")}";
    }
}
