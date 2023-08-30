using ChartExample.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Product_MainClientModel : UserPageModel
    {
        private readonly Database Db;

        [BindProperty]
        public DataTable CategoriesTable { get; set; }


        [BindProperty]
        public DataTable ProductsTable { get; set; }

        [BindProperty]
        public string  categorychoosen { get; set; }

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public int type { get; set; }

        public int rating { get; set; }
       
        public Product_MainClientModel(Database db)
        {
            Db = db;
            categorychoosen = "All";
        }
        public void OnGet()
        {
            type = Db.returnType(UserName);
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
                return RedirectToPage("/Product_MainClient");
            }
            else
            {
                CategoriesTable = Db.ReadCategories();
                ProductsTable = Db.ReadSearchProject(search);
                return RedirectToPage("/Product_MainClient", new  { search = this.search });
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
