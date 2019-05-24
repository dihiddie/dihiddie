using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User Admin { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostLogin()
        {
            return RedirectToPage("./Stories");
        }
    }
}