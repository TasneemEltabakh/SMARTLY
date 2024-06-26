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

            type = db.returnType(UserName);


        }
        public IActionResult OnPost()
        {
           
                if (!db.CheckPassword(password,UserName))
                {
                    message = "Wrong password";
                    return RedirectToPage("/CheckData",new  { UserName= this.UserName, message= this.message});
                }
                else
                {
                    message = "free";

                  return RedirectToPage("/changepassword");


            }
                  


        }


    }
}
