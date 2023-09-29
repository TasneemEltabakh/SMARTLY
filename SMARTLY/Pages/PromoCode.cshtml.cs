using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Collections.Generic;

namespace SMARTLY.Pages
{
    public class PromoCodeModel : UserPageModel
    {
        private readonly Database database;
        [BindProperty]
        public string Code { get; set; }
        [BindProperty]
        public int Percentage { get; set; }

	
		public PromoCodeModel(Database db)
		{
			database = db;
			
		}
		public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            database.addpromocode(Code, Percentage);

			return RedirectToPage("/Profile", new { UserName = this.UserName } );

		}
    }
}
