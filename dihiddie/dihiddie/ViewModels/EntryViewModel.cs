using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
