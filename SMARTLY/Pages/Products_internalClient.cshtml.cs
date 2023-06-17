using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;


namespace SMARTLY.Pages
{
    public class Products_internalClientModel : UserPageModel
    {

            private readonly Database data;
            public DataTable dt { get; set; }
            public string Categorietype { get; set; }
            public int CountFeedBack { get; set; }
             public int rating { get; set; }
        public int userrating { get; set; }
        public int id { get; set; } 

        public DataTable RateTable { get; set; }
            public DataTable ImgsTable { get; set; }
            public Products_internalClientModel(Database db)
            {
                data = db;
            }
        public void OnGet(int id)
        {
            this.id = id;
            dt = data.ReadProductRow(id);
            Categorietype = data.ReturnCategoryForProduct(Convert.ToInt32(dt.Rows[0][6]));
            CountFeedBack = data.CountFeedBackProduct(id);
            rating = data.AVGRATING(id);
            RateTable = data.ReturnRatesForProduct(id);
            ImgsTable = data.ImgsForProduct(id);
            
        }
        public IActionResult OnPostFeedback()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            int userrating = Convert.ToInt32(Request.Form["userrating"]);
            data.Insert_Feedback(UserName, id, userrating);
            return RedirectToPage("/Products_internalClient", new { id = id });
        }



    }
}
