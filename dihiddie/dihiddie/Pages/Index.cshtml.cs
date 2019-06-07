using dihiddie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            UserHelper.IsAdminMode = false;
        }
    }
}
