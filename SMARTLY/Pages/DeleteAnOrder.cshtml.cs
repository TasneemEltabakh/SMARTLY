using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class DeleteAnOrderModel : PageModel


    {
		private readonly Database database;
		
		public int OrderCode { get; set; }
        public DeleteAnOrderModel(Database db)
        {
			database = db; 
        }
        public void OnGet(int id)
        {
			OrderCode = database.ReturnOrderCode(id) ;
			

		}

	

		public IActionResult OnPost()
		{
			database.DeleteOrder(OrderCode);

			return RedirectToPage("/All_Orders");
		}
	}

	
}
