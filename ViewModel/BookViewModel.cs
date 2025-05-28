using System.ComponentModel.DataAnnotations;

namespace Library_ManagementSystem.ViewModel
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string Author { get; set; }

        [Required, MaxLength(100)]
        public string Genre { get; set; }

        [Required, MaxLength(20)]
        public string ISBN { get; set; }

        public int Quantity { get; set; }

        public IFormFile img_url { get; set; }
    }
}
