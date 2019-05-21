using dihiddie.BAL.DocxReader.Models;
using dihiddie.BAL.DocxReader.UnitOfWork;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dihiddie.Pages
{
    public class StoriesModel : PageModel
    {
        private readonly IDocxUnitOfWork docxUnitOfWotk;

        public StoriesModel(IDocxUnitOfWork uow) => docxUnitOfWotk = uow;

        public FileInfo[] Stories { get; set; }

        public void OnGet()
        {            
            Stories = docxUnitOfWotk.DocxRepository.GetAllFilesInformation();
        }
    }   
}
