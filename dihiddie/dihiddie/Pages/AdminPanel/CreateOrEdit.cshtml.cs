using AutoMapper;
using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Models;
using dihiddie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace dihiddie.Pages.AdminPanel
{
    public class CreateOrEditModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public CreateOrEditModel(IPostUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [BindProperty] public PostContentViewModel Post { get; set; } = new PostContentViewModel();

        public async  Task OnGetAsync(int? id)
        {
            UserHelper.ProcessAuthorized();
            if (id.HasValue)
            {
                var post = await unitOfWork.PostRepository.GetPostContentAsync(id.Value).ConfigureAwait(false);
                Post = mapper.Map<PostContentViewModel>(post);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var mapped = mapper.Map<PostContent>(Post);
                var savedId = await unitOfWork.PostRepository.SaveContentAsync(mapped).ConfigureAwait(false);
                TempData["PostContentId"] = savedId;
                return RedirectToPage("/AdminPanel/EntryInformation");
            }

            return null;
        }
    }
}