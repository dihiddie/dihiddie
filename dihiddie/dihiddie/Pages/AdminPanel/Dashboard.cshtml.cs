using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dihiddie.Pages.AdminPanel
{
    [Authorize]
    public class Dashboard : PageModel
    {
        private IPostUnitOfWork unitOfWork;

        public Dashboard(IPostUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public List<PostInformation> Posts { get; set; }

        public async Task OnGetAsync()
        {
            var posts = await unitOfWork.PostRepository.GetPreviewsAsync().ConfigureAwait(false);
            Posts = posts.ToList();
        }
    }
}