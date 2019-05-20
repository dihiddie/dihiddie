using dihiddie.BAL.DocxReader.Models;
using dihiddie.BAL.DocxReader.UnitOfWork;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages.SubPages
{
    public class StoryModel : PageModel
    {
        private readonly IDocxUnitOfWork docxUnitOfWotk;

        public StoryModel(IDocxUnitOfWork uow) => docxUnitOfWotk = uow;

        public FileContent StoryContent { get; set; }

        public string Title { get; set; }

        public void OnGet(string title)
        {
            Title = title;
            StoryContent = docxUnitOfWotk.DocxRepository.GetByTitle(title);
            ViewData["ShowMenu"] = false;
        }
    }
}