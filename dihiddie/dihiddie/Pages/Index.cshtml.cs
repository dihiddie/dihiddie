using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace dihiddie.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        public IndexModel(IPostUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<PostInformation> Posts { get; set; }

        public int LastElement { get; set; }

        public int PostsCount { get; set; }

        public async Task OnGetAsync()
        {
            Posts = (await unitOfWork.PostRepository.GetPreviewsAsync().ConfigureAwait(false)).ToList();
            PostsCount = Posts.Count;
            LastElement = PostsCount % 3;
            UserHelper.IsAdminMode = false;
        }
    }
}