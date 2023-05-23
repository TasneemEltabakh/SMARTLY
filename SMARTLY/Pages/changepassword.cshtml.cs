using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class changepasswordModel : UserPageModel
    {

        private readonly Database db;

        public DataTable dt { get; set; }

        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        public int type { get; set; }


        public changepasswordModel(Database database)
        {
            db = database;
        }
        public void OnGet()
        {
            type = db.getUserType;
        }
        public IActionResult OnPost()
        {


            db.updatepassword(password,UserName);
           return RedirectToPage("/ProfileClient");


            


        }

    }
}
