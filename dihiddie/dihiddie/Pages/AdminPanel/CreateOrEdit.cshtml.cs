using System;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;

namespace dihiddie.Pages.AdminPanel
{
    public class CreateOrEditModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        [BindProperty]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        public string Title { get; set; }
        
        [BindProperty]
        public string Content { get; set; }

        [BindProperty]
        public bool IsDraft { get; set; }

        public SelectList EntryList { get; set; }

        [BindProperty]
        [Required]
        public string SelectedType { get; set; }

        public CreateOrEditModel(IPostUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            EntryList = new SelectList(new string[] { "Блог","Дневник" });
        }

        public IActionResult OnGet() => UserHelper.ProcessAuthorized();

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.PostRepository.SaveAsync(new Post {Content = Encoding.UTF8.GetBytes(Content), Title = Title, IsBlogPost = !IsDraft, PreviewImagePath = "123", CreateDateTime = DateTime.Now});
                await unitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("/AdminPanel/Dashboard");
        }
    }
}