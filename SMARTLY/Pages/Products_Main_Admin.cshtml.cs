using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Products_Main_AdminModel : UserPageModel
    {
		private readonly Database Db;
        public DataTable dt { get; set; }

        [BindProperty]
		public DataTable CategoriesTable { get; set; }


		[BindProperty]
		public DataTable ProductsTable { get; set; }
        [BindProperty]
        public string AddedOne { get; set; }
        [BindProperty]
        public string search { get; set; }
        [BindProperty]
        public string categorychoosen { get; set; }

        public Products_Main_AdminModel(Database db)
		{
			Db = db;
            categorychoosen = "All";
        }
        public void OnGet()
        {
            string selectedCategory = Request.Query["selectedCategory"];
            search = Request.Query["search"];

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                OnGetByCategory(selectedCategory);
                search = "";
            }
            else if (!string.IsNullOrEmpty(search))
            {
                CategoriesTable = Db.ReadCategories();
                ProductsTable = Db.ReadSearchProject(search);


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
        public IActionResult OnPostSearch()
        {
            if (string.IsNullOrEmpty(search))
            {
                return RedirectToPage("/Products_Main_Admin");
            }
            else
            {
                CategoriesTable = Db.ReadCategories();
                ProductsTable = Db.ReadSearchProject(search);
                return RedirectToPage("/Products_Main_Admin", new { search = this.search });
            }
        }
        public IActionResult OnPostAddCategory()
        {
            int c = Db.GetMaxIdCategory() + 1;
            Db.AddCategory(c,AddedOne);
            return RedirectToPage("/Products_Main_Admin", new
            {
                UserName = this.UserName,

            });


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
			double Price = price - ((sale/100) * price);
			return Price;
		}
       
    }
}
