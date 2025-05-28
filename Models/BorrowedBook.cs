using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_ManagementSystem.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        //[ForeignKey("Member")]
        public int MemberId { get; set; }
        //public Member Member { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; } // Set default 14 days later.

        public DateTime? ReturnDate { get; set; } // Nullable, when book is returned.

        [MaxLength(50)]
        public string Status { get; set; } // Borrowed, Returned, Overdue
    }
}
