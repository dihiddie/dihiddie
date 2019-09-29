using System.Threading.Tasks;
using AutoMapper;
using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages.SubPages
{
    public class BlogPostModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public BlogPostModel(IPostUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PostContentViewModel PostContent { get; set; }

        public byte[] PreviewImage { get; set; }

        public async Task OnGet(int id)
        {
            var post = await unitOfWork.PostRepository.GetPostContentAsync(id).ConfigureAwait(false);
            PostContent = mapper.Map<PostContentViewModel>(post);
            PreviewImage = await unitOfWork.PostRepository.GetPreviewImage(id).ConfigureAwait(false);
        }
    }
}