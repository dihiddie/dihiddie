using dihiddie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace dihiddie.Pages.AdminPanel
{
    public class CreateOrEditModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        public string Title { get; set; }
        
        public string Content { get; set; }

        public SelectList EntryList { get; set; }

        [BindProperty]
        public string SelectedType { get; set; }

        public CreateOrEditModel()
        {
            EntryList = new SelectList(new string[] { "Блог","Дневник" });
        }

        public IActionResult OnGet() => UserHelper.ProcessAuthorized();

        public IActionResult OnPost()
        {
            return null;
        }
    }
}