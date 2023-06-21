using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Bundle_Item_AdminModel : UserPageModel
    {
        private readonly Database data;
        public DataTable dt { get; set; }
		public DataTable dt22 { get; set; }
		public int productnum { get; set; }

        public int BundleId { get; set; }
        public DataTable products { get; set; }
        public Bundle_Item_AdminModel(Database db)
        {
            data = db;
        }
        public void OnGet(int id)
        {
            dt=data.ReadBundleRow(id);
            productnum = data.countProductsinBundle(id);
            products = data.ProductsOfThisBundle(id);
			dt22 = data.AllProduct();
            BundleId = id;

        }
        public void OnPost(int Product_id)
        {
            data.AddProductToBundle(Product_id, BundleId);
        }

		public IActionResult OnPostEdit()
		{
            return RedirectToPage("/Edit_Bundle");
		}
	}
}
