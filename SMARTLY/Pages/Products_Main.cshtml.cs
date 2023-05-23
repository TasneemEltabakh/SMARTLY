using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Products_MainModel : PageModel
    {
        private readonly Database Db;

        [BindProperty]
        public DataTable CategoriesTable { get; set; }


        [BindProperty]
        public DataTable ProductsTable { get; set; }

        [BindProperty]
        public DataTable SearchTable { get; set; }

        [BindProperty]

        public string searchQueury { get; set; }

        [BindProperty]

        public  bool issearched { get; set; }


        [BindProperty]

        public string msg { get; set; }

        public IActionResult OnPostSearch()
        {
            SearchTable = Db.ReadSearchProject(searchQueury);
            issearched = true;
            if (SearchTable.Rows.Count == 0) msg = "No results found for this product";
            return Page();
        }
        public Products_MainModel(Database db)
        {
            Db = db;
            issearched=false;
            msg = "free";
        }
        public void OnGet()
        {

            CategoriesTable = Db.ReadCategories();
            ProductsTable = Db.ReadProduct();
        }
        public string returnCategory(int id)
        {
            string title = Db.getTitleCategory(id);
            return title;
        }
        public double returnSale(double sale)
        {
            double Sale = sale;
            return Sale;
        }
        public double price_after_sale(double price, double sale)
        {
            double Price = price - ((sale/100) * price) ;
            return Price;
        }
      

    }
}
