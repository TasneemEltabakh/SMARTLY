using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Bundle_ItemModel : PageModel
    {

            private readonly Database data;
            public DataTable dt { get; set; }
            public DataTable dt22 { get; set; }
            public int productnum { get; set; }

            public int BundleId { get; set; }
            public DataTable products { get; set; }
            public Bundle_ItemModel(Database db)
            {
                data = db;
            }
            public void OnGet(int id)
            {
                dt = data.ReadBundleRow(id);
                productnum = data.countProductsinBundle(id);
                products = data.ProductsOfThisBundle(id);
                dt22 = data.AllProduct();
                BundleId = id;

            }
            public void OnPost(int Product_id)
            {
                data.AddProductToBundle(Product_id, BundleId);
            }
        }
    }

