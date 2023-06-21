using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Add_New_BundleModel : UserPageModel
    {
        private readonly Database data;

        [BindProperty]
        public Bundle bundle { get; set; }
        

        public Add_New_BundleModel(Database db)
        {
            data = db;
        }
        public void OnGet()
        {
		}
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bundle.BundleId = Convert.ToString( data.GetMaxBundleId());
                data.AddNewBundle(bundle);
                return RedirectToPage("/Bundle_Out_Admin");
            }
            else
            {
                return Page();
            }
        }
    }
}

