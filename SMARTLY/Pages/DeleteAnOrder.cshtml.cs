using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteAnOrderModel : UserPageModel


    {
		private readonly Database database;


        [BindProperty]

        public int ordercode { get; set; }

        public DeleteAnOrderModel(Database db)
        {
            database = db;
        }

        public void OnGet(int ordercode)
        {

            this.ordercode = ordercode;

        }
        public IActionResult OnPost()
        {
            database.DeleteOrder(ordercode);
            return RedirectToPage("/All_Orders");
        }

    }


}
