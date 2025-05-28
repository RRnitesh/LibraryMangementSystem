using Library_ManagementSystem.Database;
using Library_ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_ManagementSystem.Controllers
{
    public class RequestController : Controller
    {
        public ApplicationDbcontext _context;

        public RequestController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpPost]
        public  IActionResult RequestBook(int bookId,string bookTitle)
        {
            var book =  _context.Books.Find(bookId);

            //if (book == null || book.Quantity <= 0)
            //{
            //    TempData["ErrorMessage"] = "Sorry, book is currently not avaiable";
            //    return RedirectToAction("Index", "Home");
            //    //"action" "controller"
            //}

            //var userId = User.Identity.Name;
            var userid = 1;
            var existingRequest = _context.BookRequests
                .FirstOrDefault(r => r.BookId == bookId && r.UserId == userid);

            if (existingRequest != null)
            {
                TempData["ErrorMessage"] = "You have Already Requested this book";
                return RedirectToAction("Index", "Home");
            }

            var request = new BookRequest
            {
                BookId = bookId,
                UserId = userid,
                Title = bookTitle,
                RequestDate = DateTime.UtcNow
            };

            _context.BookRequests.Add(request);
            
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Book request submitted successfully";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewRequest()
        {
            var requests = _context.BookRequests.ToList();

            return View(requests);
        }

        [HttpPost]
        public IActionResult AcceptRequest(int requestId)
        {

            var request = _context.BookRequests.FirstOrDefault(r => r.id ==  requestId);
            if (request == null)
            {
                TempData["ErrorMessage"] = "Request not found";
                return RedirectToAction("Index", "Home");
            }
            var bookid = request.BookId;
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookid);

            if(book == null || book.Quantity <= 0)
            {
                TempData["ErrorMessage"] = "Sorry, book is not avaiable";
                return RedirectToAction("ViewRequest");
            }
            
            //book.Quantity -= 1;
            var userID = 1;
            var borrowedBook = new BorrowedBook
            {
                BookId = bookid,
                //MemberId = request.UserId,
                MemberId = userID,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14),
                Status = "Borrowed"
                
            };

            _context.BorrowedBooks.Add(borrowedBook);
            _context.BookRequests.Remove(request);

            
            
                _context.SaveChanges();
            
            //catch (Exception ex)
            //{
            //    // Log ex if possible; for now, just return an error message.
            //    TempData["ErrorMessage"] = "An error occurred while processing the request.";
            //    return RedirectToAction("ViewRequest");
            //}

            TempData["SuccessMessage"] = "Book Request approved";
            return RedirectToAction("ViewRequest");
        }

        [HttpPost]
        public IActionResult RejectRequest(int requestId)
        {
            var request = _context.BookRequests.FirstOrDefault(a => a.id == requestId);
            if (request == null)
            {
                TempData["ErrorMessage"] = "Invalid request id";
                return RedirectToAction("ViewRequest");
            }

            _context.BookRequests.Remove(request);
            _context.SaveChanges();
            return RedirectToAction("ViewRequest");
        }
    }
}