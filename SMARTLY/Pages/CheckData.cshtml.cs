using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CheckDataModel : UserPageModel
    {
       
        private readonly Database db;

        public DataTable dt { get; set; }

        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        public int type { get; set; }

        public string message { get; set; }    

        public CheckDataModel(Database database)
        {
            db = database;
        }
        public void OnGet()
        {

            type = db.getUserType;


        }
        public IActionResult OnPost()
        {
           
                if (!db.CheckPassword(password,UserName))
                {
                    message = "Wrong password";
                    return Page();
                }
                else
                {
                    message = "free";

                return RedirectToPage("/changepassword");


                 }



        }


    }
}
