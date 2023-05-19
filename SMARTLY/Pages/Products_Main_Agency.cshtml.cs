using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Products_Main_AgencyModel : PageModel
    {
		private readonly Database Db;

		[BindProperty]
		public DataTable CategoriesTablex { get; set; }


		[BindProperty]
		public DataTable ProductsTablex { get; set; }

		public Products_Main_AgencyModel(Database db)
		{
			Db = db;
		}
		public void OnGet()
        {
			CategoriesTablex = Db.ReadCategories();
            ProductsTablex = Db.ReadProduct();
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
