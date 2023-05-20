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
        public Product_internal_AdminModel(Database db)
        {
            data = db;
        }
        public void OnGet(int id)
        {
            dt = data.ReadProductRow(id);
            Categorietype = data.ReturnCategoryForProduct(id);
            CountFeedBack = data.CountFeedBackProduct(id);
        }
        public void OnPost() { 
        
        }
    }
}
