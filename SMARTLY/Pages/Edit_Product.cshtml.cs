using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;
using ChartExample.Models.Chart;
using System.Text;

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
		public int category { get; set; }
		[BindProperty]
		public DataTable dtt { get; set; }
		[BindProperty]
		public DataTable tableimg { get; set; }
		[BindProperty]
		public DataTable Dt { get; set; }

		[BindProperty]
		public int idd { get; set; }

		[BindProperty]
		public Product Product { get; set; }
		[BindProperty]
		public List<IFormFile> Image123 { get; set; }

		[BindProperty]
		public List<IFormFile> Image111 { get; set; }
		[BindProperty]
		public byte[] Pimage11 { get; set; }
		[BindProperty]
		public List<IFormFile> Image222 { get; set; }
		[BindProperty]
		public byte[] Pimage22 { get; set; }
		[BindProperty]
		public List<IFormFile> Image333 { get; set; }
		[BindProperty]
		public byte[] Pimage33 { get; set; }
		public void OnGet(int id)
		{
			Dt = db.ReadProduct(id);
			tableimg = db.ReadProduct_Imgs(id);
			if (Dt != null && Dt.Rows.Count != 0)
			{
				Product = new Product
				{
					PId = Convert.ToInt32(Dt.Rows[0][0]),
					PName = Convert.ToString(Dt.Rows[0][1]),
					price = Convert.ToInt64(Dt.Rows[0][2]),
					price_in_bundle = Convert.ToInt64(Dt.Rows[0][11]),
					Quantity = Convert.ToInt32(Dt.Rows[0][3]),
					color = Convert.ToString(Dt.Rows[0][4]),
					salePercentage = Convert.ToInt64(Dt.Rows[0][5]),
					category = Convert.ToInt32(Dt.Rows[0][6]),
					AdditionalNotes = Convert.ToString(Dt.Rows[0][7]),
					Pimage = (byte[])Dt.Rows[0][8],
				};
			}

			dtt = db.ReadCategoryForAddProduct();
		}
		public async Task<IActionResult> OnPost()
		{
			if (string.IsNullOrEmpty(Request.Form["category"]))
			{
				Product.category = 3;
			}
			else
			{
				int category = Convert.ToInt32(Request.Form["category"]);
				Product.category = category;
			}
			foreach (var item in Image123)
			{
				if (item.Length > 0)
				{
					using (var stream = new MemoryStream())
					{
						await item.CopyToAsync(stream);
						Product.Pimage = stream.ToArray();
					}
				}
			}
			foreach (var item in Image111)
			{
				if (item.Length > 0)
				{
					using (var stream = new MemoryStream())
					{
						await item.CopyToAsync(stream);
						Pimage11 = stream.ToArray();
					}
				}
			}
			foreach (var item in Image222)
			{
				if (item.Length > 0)
				{
					using (var stream = new MemoryStream())
					{
						await item.CopyToAsync(stream);
						Pimage22 = stream.ToArray();
					}
				}
			}
			foreach (var item in Image333)
			{
				if (item.Length > 0)
				{
					using (var stream = new MemoryStream())
					{
						await item.CopyToAsync(stream);
						Pimage33 = stream.ToArray();
					}
				}
			}
			db.Edit_Product(Product);

			db.EditImgNewProduct(Product.PId, Product.Pimage,1);

			db.EditImgNewProduct(Product.PId, Pimage11,2);

			db.EditImgNewProduct(Product.PId, Pimage22,3);

			db.EditImgNewProduct(Product.PId, Pimage33,4);
			return RedirectToPage("/Products_Main_Admin");
		}
	}
}
