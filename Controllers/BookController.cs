
using Microsoft.AspNetCore.Mvc;
using Library_ManagementSystem.Models;
using Library_ManagementSystem.Database;
using Microsoft.EntityFrameworkCore;
using Library_ManagementSystem.ViewModel;
using Microsoft.AspNetCore.Hosting;
namespace Library_ManagementSystem.Controllers
{
    public class BookController : Controller
    {
        public ApplicationDbcontext _context;
        private IWebHostEnvironment _hostenvironment;
        public BookController(ApplicationDbcontext context, IWebHostEnvironment hostenvironment)
        {
            _context = context;
            _hostenvironment = hostenvironment;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        //simply display the form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel model)
            //data being sent from the view to the controller.
        {
            if (ModelState.IsValid)
            {
                 
                if(model.img_url != null)
                {
                    string upLoadFolder = Path.Combine(_hostenvironment.WebRootPath, "images/Books");
                //_hostenvimonet => used to get the applications root path(wwwroot) get path to wwwroot folder
                    string fileName = model.img_url.FileName;
                    //orginal dile name 'form data'. 
                    //model.img_url => ifromfile 
                    //filename => name fo the file user uploads;
                    string filepath = Path.Combine(upLoadFolder, fileName);

                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        await model.img_url.CopyToAsync(filestream);
                    }
                    var book = new Book
                    {
                        Title = model.Title,
                        Author = model.Author,
                        Genre = model.Genre,
                        ISBN = model.ISBN,
                        Quantity = model.Quantity,
                        img_url = fileName
                    };
                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index"); //list
                }

            }
            return View(model);
        }

        public IActionResult Details(int Id) 
        { 
            var book = _context.Books.Find(Id);
            if(book != null)
            return View(book);

            return NotFound();
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if(book != null)
                return View(book);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Book book)
        {
            if (id != book.BookId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            // Delete the image from wwwroot/images/

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Books", book.img_url);

             System.IO.File.Delete(imagePath);
                
      
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }
}
