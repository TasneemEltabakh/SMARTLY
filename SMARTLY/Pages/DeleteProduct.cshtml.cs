using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteProductModel : UserPageModel
    {
		private readonly Database database;


		//[BindProperty]

		static public string PId { get; set; }

        public DeleteProductModel(Database db)
        {
			database = db;
		}

        public void OnGet(string id)
        {
			PId = id;
		}
		public IActionResult OnPost()
		{
			database.DeleteProduct(PId);
			return RedirectToPage("/Products_Main_Admin");
		}
	}
}
