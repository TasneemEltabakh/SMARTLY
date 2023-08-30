using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Bundle_ItemClientModel : UserPageModel
    {
            private readonly Database data;
            public DataTable dt { get; set; }
            public DataTable dt22 { get; set; }
            public int productnum { get; set; }
            [BindProperty]
            public int type { get; set; }
            public int BundleId { get; set; }
            public DataTable products { get; set; }
            public Bundle_ItemClientModel(Database db)
            {
                data = db;
            }
            public void OnGet(int id)
            {
                type = data.returnType(UserName);
                dt = data.ReadBundleRow(id);
                productnum = data.countProductsinBundle(id);
                products = data.ProductsOfThisBundle(id);
                dt22 = data.AllProduct();
                BundleId = id;

            }
            public void OnPost()
            {
			
		    }
        }
    }

