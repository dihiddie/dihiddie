using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dihiddie.Models
{
    public static class UserHelper
    {
        public static bool IsAdminAutorized { get; set; }

        public static  bool IsAdminMode { get; set; }

        public static IActionResult ProcessAuthorized()
        {
            if (!IsAdminAutorized)
            {
                // HttpContext.Response.StatusCode = 401;                
                return new RedirectToPageResult("/Error/Unauthorized");
            }
            UserHelper.IsAdminMode = true;
            return null;
        }
    }
}
