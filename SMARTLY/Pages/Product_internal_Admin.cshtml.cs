using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Product_internal_AdminModel : UserPageModel
    {
        private readonly Database data;
        public DataTable dt { get; set; }
        public string Categorietype { get; set; }
        public int CountFeedBack { get; set; }
        public int rating { get; set; }
        [BindProperty]
        public int type { get; set; }
        public DataTable RateTable { get; set; }
        public DataTable ImgsTable { get; set; }
        public Product_internal_AdminModel(Database db)
        {
            data = db;
        }
        public void OnGet(int id)
        {
            type = data.returnType(UserName);
            dt = data.ReadProductRow(id);
            Categorietype = data.ReturnCategoryForProduct((int)dt.Rows[0][6]);
            CountFeedBack = data.CountFeedBackProduct(id);
            rating = data.AVGRATING(id);
            RateTable = data.ReturnRatesForProduct(id);
			ImgsTable = data.ImgsForProduct(id);
		}
        public void OnPost() { 
        
        }
    }
}
