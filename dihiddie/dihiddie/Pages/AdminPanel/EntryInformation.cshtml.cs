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

        [BindProperty]
        public EntryViewModel Post { get; set; } = new EntryViewModel();

        public static int PostContentId { get; set; }

        public EntryInformationModel(IPostUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Post.EntryList = new SelectList(new string[] { "Блог", "Дневник" });
        }
     
        [DisplayName("Выберите картинку для превью")]
        public string PreviewImagePath { get; set; }

        [BindProperty]
        [DisplayName("Выберите картинку для превью")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile PreviewImage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var mappedPost = mapper.Map<PostInformation>(Post);
            mappedPost.PreviewImagePath = PreviewImage.FileName;
            mappedPost.PreviewImage = GetBytesFromPreviewImage();
            mappedPost.PostContentId = int.Parse(TempData["PostContentId"].ToString());

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