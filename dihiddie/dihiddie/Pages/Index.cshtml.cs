using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dihiddie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        public IndexModel(IPostUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<PostInformation> Posts { get; set; }

        public async Task OnGetAsync()
        {
            var posts = await unitOfWork.PostRepository.GetPreviewsAsync().ConfigureAwait(false);
            Posts = posts.ToList();
            UserHelper.IsAdminMode = false;
        }
    }
}
