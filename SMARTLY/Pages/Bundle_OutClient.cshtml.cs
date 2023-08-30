

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Bundle_OutClientModel : UserPageModel
    {
        private readonly Database Db;


        [BindProperty]
        public int type { get; set; }
        [BindProperty]
        public DataTable dt { get; set; }


        public Bundle_OutClientModel(Database db)
        {
            Db = db;
        }
        public void OnGet()
        {
            type = Db.returnType(UserName);

            dt = Db.ReadBundle();
        }

        public double returnSale(double sale)
        {
            double Sale = sale;
            return Sale;
        }
        public double price_after_sale(double price, double sale)
        {
            double Price = price - ((sale / 100) * price);
            return Price;
        }
    }
}
