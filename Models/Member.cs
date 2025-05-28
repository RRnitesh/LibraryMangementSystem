using System.ComponentModel.DataAnnotations;

namespace Library_ManagementSystem.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required, MaxLength(255)]
        public string FullName { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
