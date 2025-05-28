using Library_ManagementSystem.Database;
using Library_ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_ManagementSystem.Controllers
{
    public class BorrowBookController : Controller
    {
        public ApplicationDbcontext _context;
        public BorrowBookController(ApplicationDbcontext context)
        {
            _context = context;
        }

        //display data
        public IActionResult BorrowIndex()
        {

            var books = _context.BorrowedBooks.ToList();
            return View(books);
        }

        public IActionResult BorrowEdit(int id)
        {
            var book = _context.BorrowedBooks.Find(id);
            
            return View(book);
        }

        [HttpPost]
        public IActionResult BorrowEdit(BorrowedBook borrowbook)
        {

            //if (ModelState.IsValid)
            //{
                var existBook = _context.BorrowedBooks.Find(borrowbook.BorrowId);
            //&& borrowbook.Status != "Returned"
            if (existBook != null )
                {
                    //if(borrowbook.Status == "Returned")
                    //{
                    //    existBook.ReturnDate = DateTime.Now;
                    //}
                    existBook.ReturnDate = borrowbook.ReturnDate;
                    existBook.Status = borrowbook.Status;
                    _context.SaveChanges();
                    TempData["SuccessBorrow"] = "status updated sccuessfully";
                    return RedirectToAction("BorrowIndex");
                }
            //}
            TempData["ErrorBorrow"] = "Failed to update status";
            return View(borrowbook);
        }

        [HttpPost]
        public IActionResult BorrowDelete(int id)
        {
            var book = _context.BorrowedBooks.Find(id);
            if (book != null)
            {
                _context.BorrowedBooks.Remove(book);
                _context.SaveChanges();
                TempData["SuccessBorrow"] = "Successfull Deletion complete";
                return RedirectToAction("BorrowIndex");
            }
            TempData["ErrorBorrow"] = "No item in the database";
            return RedirectToAction("BorrowIndex");
        }

        public IActionResult BorrowCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult BorrowCreate(BorrowedBook borrowdbook)
        {
            if (ModelState.IsValid)
            {
                _context.BorrowedBooks.Add(borrowdbook);
                _context.SaveChanges();
                TempData["SuccessBorrow"] = "book successfully borrowed";
                return RedirectToAction("BorrowIndex");
            }
            TempData["ErrorBorrow"] = "failed to create borrowd book entry";
            return View(borrowdbook);
        }
    }
}
