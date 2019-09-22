using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using dihiddie.DAL.Post.Core.Models;

namespace dihiddie.Pages.AdminPanel
{
    [BindProperties(SupportsGet = true)]
    public class EntryInformationModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        [BindProperty]
        public EntryViewModel Post { get; set; } = new EntryViewModel();

        public static int PostContentId { get; set; }

        public EntryInformationModel(IPostUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Post.EntryList = new SelectList(new string[] { "Блог", "Дневник" });
        }

        public void OnGet(object savedId)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Post.PreviewImagePath = "111";
            var mappedPost = mapper.Map<PostInformation>(Post);
            mappedPost.PostContentId = int.Parse(TempData["PostContentId"].ToString());
            await unitOfWork.PostRepository.SaveAsync(mappedPost);

            return RedirectToPage("/AdminPanel/Dashboard");
        }
    }
}