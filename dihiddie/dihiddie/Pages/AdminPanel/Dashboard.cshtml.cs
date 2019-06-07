using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages.AdminPanel
{
    public class Dashboard : PageModel
    {
        public IActionResult OnGet()
        {
            return UserHelper.ProcessAuthorized();
        }
    }
}