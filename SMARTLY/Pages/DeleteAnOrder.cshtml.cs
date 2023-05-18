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
			

		}

	

		public void OnPost()
		{
			database.DeleteOrder(OrderCode);

			
		}
	}

	
}
