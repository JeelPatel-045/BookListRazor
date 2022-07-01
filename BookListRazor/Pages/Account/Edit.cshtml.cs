using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.Account
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDB = await _db.Book.FindAsync(Book.Id);
                BookFromDB.Name = Book.Name;
                BookFromDB.ISBN= Book.ISBN;
                BookFromDB.Author = Book.Author;
                BookFromDB.quantity = Book.quantity;


                await _db.SaveChangesAsync();

                return RedirectToPage("Welcome");
            }
            return RedirectToPage();
        }
    }
}
