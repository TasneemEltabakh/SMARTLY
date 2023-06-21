using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Products_Main_AgencyModel : PageModel
    {
        private readonly Database Db;
        public DataTable dt { get; set; }

        //[BindProperty]
        public DataTable CategoriesTable { get; set; }


        [BindProperty]
        public string categorychoosen { get; set; }

        [BindProperty]
        public DataTable ProductsTable { get; set; }


		[BindProperty]
		public string search { get; set; }
		public Products_Main_AgencyModel(Database db)
         {
                Db = db;
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
                double Price = price - ((sale / 100) * price);
                return Price;
            }

    }
}
