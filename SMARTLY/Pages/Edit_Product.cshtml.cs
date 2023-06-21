using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;
using ChartExample.Models.Chart;

namespace SMARTLY.Pages
{
	public class Edit_ProductModel : UserPageModel
	{
		private readonly Database db;
		public Edit_ProductModel(Database data)
		{
			db = data;
		}
		[BindProperty]
		public DataTable Dt { get; set; }

		[BindProperty]
		public int idd { get; set; }

		[BindProperty]
		public Product Product { get; set; }

		public void OnGet(int id)
		{
			Dt = db.ReadProduct(id);

			if (Dt != null && Dt.Rows.Count != 0)
			{
				Product = new Product
				{
					PId = Convert.ToInt32(Dt.Rows[0][0]),
					PName = Convert.ToString(Dt.Rows[0][1]),
					price = Convert.ToInt64(Dt.Rows[0][2]),
					Quantity = Convert.ToInt32(Dt.Rows[0][3]),
					color = Convert.ToString(Dt.Rows[0][4]),
					salePercentage = Convert.ToInt64(Dt.Rows[0][5]),
					category = Convert.ToInt32(Dt.Rows[0][6]),
					AdditionalNotes = Convert.ToString(Dt.Rows[0][7]),
				};
			}
		}
		public IActionResult OnPost()
		{
			db.Edit_Product(Product);
			return RedirectToPage("/Products_Main_Admin");
		}
	}
}
