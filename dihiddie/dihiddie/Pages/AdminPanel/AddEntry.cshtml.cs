using dihiddie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages.AdminPanel
{
    public class AddEntryModel : PageModel
    {
        public IActionResult OnGet()
        {
            return UserHelper.ProcessAuthorized();
        }
    }
}