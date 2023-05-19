using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteProductModel : PageModel
    {
		private readonly Database database;


		[BindProperty]

		public int PId { get; set; }

        public DeleteProductModel(Database db)
        {
			database = db;
		}

        public void OnGet(int PId)
        {
			this.PId = PId;
		}
		public IActionResult OnPost()
		{
			database.DeleteProduct(PId);
			return RedirectToPage("/Products_Main_Admin");
		}
	}
}
