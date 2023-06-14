using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Products_MainModel : UserPageModel
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

        [BindProperty]
        public string categorychoosen { get; set; }


        public IActionResult OnPostSearch()
        {
            SearchTable = Db.ReadSearchProject(searchQueury);
            issearched = true;
            if (SearchTable.Rows.Count == 0) msg = "No results found for this product";
            else msg = "free";
            return Page();
           
        }
        public Products_MainModel(Database db)
        {
            Db = db;
            msg = "free";
            categorychoosen = "All";
        }
        public void OnGet()
        {
            string selectedCategory = Request.Query["selectedCategory"];
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                OnGetByCategory(selectedCategory);
            }
            else
            {
                CategoriesTable = Db.ReadCategories();
                ProductsTable = Db.ReadProduct();
            }
        }

        public void OnGetByCategory(string selectedCategory)
        {
            CategoriesTable = Db.ReadCategories();
            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "All")
            {
                ProductsTable = Db.ReadProduct();
                categorychoosen = "All";
            }
            else
            {
                categorychoosen = selectedCategory;
                ProductsTable = Db.ReadProductspecificcategory(categorychoosen);
            }
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
