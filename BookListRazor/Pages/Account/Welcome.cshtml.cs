using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Account
{
    public class WelcomeModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public WelcomeModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { set; get; }

        public string UserName;
        public async Task OnGet()
        {
            UserName = HttpContext.Session.GetString("username");
            
            Books = await _db.Book.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            
                var book = await _db.Book.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }
                _db.Book.Remove(book);

                await _db.SaveChangesAsync();

                return RedirectToPage("Welcome");
            
        }
    }
}
