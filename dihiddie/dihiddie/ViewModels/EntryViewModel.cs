using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace dihiddie.ViewModels
{
    public class EntryViewModel
    {
        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        [Required]
        public string SelectedType { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        [DisplayName("Сохранить в черновик")]
        public bool IsDraft { get; set; }

        public bool IsBlogPost
        {
            get { return SelectedType == "Блог"; }
        }

        public SelectList EntryList { get; set; }

        [DisplayName("Выберите картинку для превью")]
        public string PreviewImagePath { get; set; }

        [DisplayName("Выберите картинку для превью")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile PreviewImage { get; set; }
    }
}
