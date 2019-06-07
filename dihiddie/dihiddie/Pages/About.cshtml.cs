using dihiddie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            UserHelper.IsAdminMode = false;
        }
    }
}
