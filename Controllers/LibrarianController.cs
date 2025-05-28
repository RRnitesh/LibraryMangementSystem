using Microsoft.AspNetCore.Mvc;

namespace Library_ManagementSystem.Controllers
{
    public class LibrarianController : Controller
    {


        [HttpPost]
        public IActionResult Login()
        {

            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult Logout()
        {

            return Json(new{status = false});
        }
    }
}
