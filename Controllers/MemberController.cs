using Microsoft.AspNetCore.Mvc;
using Library_ManagementSystem.Database;
using Library_ManagementSystem.Models;
namespace Library_ManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        public ApplicationDbcontext _context;
        public MemberController(ApplicationDbcontext context)
        {
            _context = context;
        }

        //display total number of member
        public IActionResult IndexMember()
        {
            var members = _context.Members.ToList();
            return View(members);
        }
        //display form
        public IActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMember(Member member)
        {         
            if(ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("IndexMember");
            }
            return View(member);
        }

        public IActionResult EditMember(int  id)
        {
            var member = _context.Members.Find(id);
            return View(member);
        }
        [HttpPost]
        public IActionResult EditMember(int id, Member member)
        {
            if( id != member.MemberId )
            { return NotFound(); }

            if(ModelState.IsValid )
            {
                _context.Members.Update(member);
                _context.SaveChanges();
                return RedirectToAction("IndexMember");
            }
            return View(member);
        }
        [HttpPost]
        public IActionResult DeleteMember(int id)
        {
            var member = _context.Members.Find(id);
            if( member == null ) { return NotFound(); }
            _context.Members.Remove(member);
            _context.SaveChanges();
            return RedirectToAction("IndexMember");
        }
        public IActionResult DetailsMember(int id)
        {
            
            var member = _context.Members.Find(id);
            if(member == null ) { return NotFound(); }
            return View(member);
        }
    }
}
