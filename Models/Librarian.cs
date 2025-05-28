using System.ComponentModel.DataAnnotations;

namespace Library_ManagementSystem.Models
{
    public class Librarian
    {
        [Key]
        public int LibrarianId { get; set; }
     
        public string Username { get; set; }

        public string PasswordHash { get; set; }
  
        public string Email { get; set; }

    }
}
