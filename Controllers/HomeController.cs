using Library_ManagementSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_ManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbcontext _context;
        public HomeController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // Action to fetch random books
        public async Task<IActionResult> Index()
        {

            var randomBooks = await _context.Books
                                            .FromSqlRaw("SELECT TOP 6 * FROM Books ORDER BY NEWID()")
                                            .ToListAsync();

            return View(randomBooks);
        }
    }
}
