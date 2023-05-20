using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Add_New_BundleModel : PageModel
    {
        private readonly Database database;

        public DataTable dt { get; set; } 

        [BindProperty]
        public Bundle bundle { get; set; }
        

        public string msg { get; set; }
        public int getmax { get; set; }
        public Add_New_BundleModel(Database db)
        {
            this.database = db;
        }
        public void OnGet()
        {
            msg = "free";
            getmax = database.GetMax("Bundle","BundleId");
            
			//user.usertype = 0;

		}
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                   
                    //user.usertype = 3;
                    database.Insert_New_Bundle(bundle);
                    return RedirectToPage("/Bundle_Item_Admin");
                msg = "WE HAVE RECIVED YOUR MESSAGE ";

            }
            else
                return Page();
        }
    }
}

