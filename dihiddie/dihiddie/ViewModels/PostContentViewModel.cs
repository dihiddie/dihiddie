using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace dihiddie.ViewModels
{
    public class PostContentViewModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }
    }
}
