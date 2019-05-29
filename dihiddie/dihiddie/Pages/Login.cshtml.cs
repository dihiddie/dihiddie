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
        private const string adminLogin = "admin";

        private const string adminPassword = "admin";

        [BindProperty]
        public User Admin { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            if (UserHelper.IsAdminAutorized)
                return RedirectToPage("./Stories");
            return null;
        }

        public IActionResult OnPostLogin()
        {            
            SetErrorMessage(false);            
            if(!IsValid())
            {
                SetErrorMessage(true);
                return null;
            }
            UserHelper.IsAdminAutorized = true;
            return RedirectToPage("./AdminPanel/AdminPanel");
        }

        private void SetErrorMessage(bool isError) => ErrorMessage = isError ? "Вы не авторизированы" : string.Empty;

        private bool IsValid()
        {
            if (Admin.UserName == null && Admin.Password == null) return true;
            return Admin.UserName.Equals(adminLogin) && Admin.Password.Equals(adminPassword);
        }

    }
}
