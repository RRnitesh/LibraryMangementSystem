namespace Library_ManagementSystem.Models
{
    public class BookRequest
    { 

            public int id { get; set; }

            public int BookId { get; set; }

            public int UserId {  get; set; }

            public string Title { get; set; }

            public DateTime RequestDate { get; set; }

            public Book Book { get; set; }
        
    }
}
