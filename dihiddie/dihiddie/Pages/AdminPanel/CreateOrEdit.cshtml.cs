using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dihiddie.Pages.AdminPanel
{
    public class CreateOrEditModel : PageModel
    {
        public SelectList EntryList { get; set; }

        public CreateOrEditModel()
        {
            EntryList = new SelectList(new string[] { "Блог","Дневник" });
        }

        public void OnGet()
        {

        }
    }
}