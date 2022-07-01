using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.Account
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public string Msg;
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
           if(UserName.Equals("Admin") && Password.Equals("admin!123"))
            {
                HttpContext.Session.SetString("username", UserName);
                return RedirectToPage("Welcome");
            }
            else
            {
                Msg = " Invalid ";
                return Page();
            }
        }
    }
}
