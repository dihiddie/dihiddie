using dihiddie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages.AdminPanel
{
    [Authorize]
    public class AddEntryModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}