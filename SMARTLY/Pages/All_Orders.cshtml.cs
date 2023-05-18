using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class All_OrdersModel : PageModel
    {
        private readonly Database database;
        public DataTable dt { get; set; }
      
        public All_OrdersModel(Database database)
        {

            this.database = database;
        }
        public void OnGet()
        {
            dt = database.loadTableofOrder();

        }
        public void OnPost()
        {
            
        }
    }
}
