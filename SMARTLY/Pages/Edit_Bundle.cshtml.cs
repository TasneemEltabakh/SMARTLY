using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;
using ChartExample.Models.Chart;
using Newtonsoft.Json.Linq;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace SMARTLY.Pages
{
    public class Edit_BundleModel : UserPageModel
	{
		private readonly Database db;
		public Edit_BundleModel(Database data)
		{
			db = data;
		}
		[BindProperty]
		public DataTable Dt { get; set; }

		[BindProperty]
		public int idd { get; set; }

		[BindProperty]
		public Bundle Bundle { get; set; }

		public void OnGet(int id)
        {
			Dt = db.ReadBudle(id);
			dt22 = db.ProductsNotInThisBundle(id); //*
			dt33 = db.ProductsInThisBundle(id); //*
			if (Dt != null && Dt.Rows.Count != 0)
			{
				Bundle = new Bundle
				{
					Name = Convert.ToString(Dt.Rows[0][4]),
					price = Convert.ToString(Dt.Rows[0][1]),
					Description = Convert.ToString(Dt.Rows[0][3]),
					BundleId = Convert.ToString(Dt.Rows[0][0]),
				};
			}
		}
		//public IActionResult OnPost()
		//{
		//	db.Edit_Bundle(Bundle.Name, Bundle.Description, Bundle.price, Bundle.BundleId);
		//  db.AddProductToBundle(2, 3);
		//	return RedirectToPage("/Bundle_Out_Admin");
		//}
		public DataTable dt22 { get; set; }
		public DataTable dt33 { get; set; }
		[BindProperty]
		public List<string> SelectedCheckboxes { get; set; }


		[BindProperty]
		public List<string> SelectedCheckboxes22 { get; set; }

		public IActionResult OnPost()
		{
			
			if (SelectedCheckboxes != null)
			{
				for (int i = 0; i < SelectedCheckboxes.Count ; i++)
				{
					if(db.Isfound(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId)) ==1)
					{
						int x = db.whatisthequanity(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId)) + 1;
						db.Updatequantity(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId), x);
						db.UpdateBundlePriceWhenAddNewProduct(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId));
					}
					else
					{
                        db.AddProductToBundle(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId));
                        db.UpdateBundlePriceWhenAddNewProduct(Convert.ToInt32(SelectedCheckboxes[i]), Convert.ToInt32(Bundle.BundleId));
                    }
					

				}
			}

			if (SelectedCheckboxes22 != null)
			{
				for (int i = 0; i < SelectedCheckboxes22.Count; i++)
				{
					if (db.whatisthequanity(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId)) > 1)
					{
						int x = db.whatisthequanity(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId)) - 1;
						db.Updatequantity(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId), x);
						db.UpdateBundlePriceWhenDeleteProduct(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId));
					}
					else
					{
						db.UpdateBundlePriceWhenDeleteProduct(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId));
						db.DeleteProductsFromBundle(Convert.ToInt32(SelectedCheckboxes22[i]), Convert.ToInt32(Bundle.BundleId));
					}
				}
			}

			// Redirect to a different page or perform any other necessary actions
			db.Edit_Bundle(Bundle.Name, Bundle.Description, Bundle.BundleId);
			return RedirectToPage("/Bundle_Out_Admin");
		}
	}
}

