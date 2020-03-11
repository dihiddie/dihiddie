using dihiddie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Utils.PasswordHasher;

namespace dihiddie.Pages
{
    public class LoginModel : PageModel
    {
        private const string adminLogin = "admin";

        private const string adminPassword = "admin";

        private readonly IUserUnitOfWork userUnitOfWork;

        public LoginModel(IUserUnitOfWork userUnitOfWork)
        {
            this.userUnitOfWork = userUnitOfWork;
        }

        [BindProperty]
        public User Admin { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            UserHelper.IsAdminMode = false;
            return null;
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            SetErrorMessage(false);            
            if(!await IsPasswordValidAsync().ConfigureAwait(false))
            {
                SetErrorMessage(true);
                return null;
            }

            await AuthenticateAsync(adminLogin).ConfigureAwait(false);
            return RedirectToPage("./AdminPanel/Dashboard");
        }

        private void SetErrorMessage(bool isError) => ErrorMessage = isError ? "Вы не авторизированы" : string.Empty;

        private async Task<bool> IsPasswordValidAsync()
        {
            var passwordHash = await userUnitOfWork.UserRepository.GetPasswordAsync(Admin.UserName).ConfigureAwait(false);
            return PasswordHash.ValidatePassword(Admin.Password, passwordHash);
        }

        private async Task AuthenticateAsync(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
