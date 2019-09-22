using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            var previews = await unitOfWork.PostRepository.GetPreviewsAsync().ConfigureAwait(false);
            UserHelper.IsAdminMode = false;
        }
    }
}
