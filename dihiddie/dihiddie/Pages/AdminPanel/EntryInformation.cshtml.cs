using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using dihiddie.DAL.Post.Core.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.IO;

namespace dihiddie.Pages.AdminPanel
{
    [BindProperties(SupportsGet = true)]
    public class EntryInformationModel : PageModel
    {
        private readonly IPostUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly SelectList SelectList = new SelectList(new string[] {"Блог", "Дневник"});

        private static int postId;

        [BindProperty]
        public EntryViewModel Post { get; set; } = new EntryViewModel();

        public static int PostContentId { get; set; }

        public EntryInformationModel(IPostUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Post.EntryList = SelectList;
        }
     
        [DisplayName("Выберите картинку для превью")]
        public string PreviewImagePath { get; set; }

        [BindProperty]
        [DisplayName("Выберите картинку для превью")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile PreviewImage { get; set; }

        public async Task OnGetAsync()
        {
            postId = int.Parse(TempData["PostContentId"].ToString());
            var postInformation = await unitOfWork.PostRepository.GetPostInformationByPostId(postId);
            if (postInformation == null) return;
            Post = mapper.Map<EntryViewModel>(postInformation);
            Post.EntryList = SelectList;
            if (Post.IsBlogPost) Post.SelectedType = "Блог";
            else Post.SelectedType = "Дневник";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mappedPost = mapper.Map<PostInformation>(Post);
            if(PreviewImage != null)
                mappedPost.PreviewImage = GetBytesFromPreviewImage();
            mappedPost.PostContentId = postId;
            mappedPost.IsBlogPost = Post.SelectedType == "Блог";

            await unitOfWork.PostRepository.SaveAsync(mappedPost);
            return RedirectToPage("/AdminPanel/Dashboard");
        }

        private byte[] GetBytesFromPreviewImage()
        {
            using (var ms = new MemoryStream())
            {
                PreviewImage.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}