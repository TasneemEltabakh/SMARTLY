using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CheckOutModel : UserPageModel
    {
        
        private readonly Database db;

        public DataTable dt { get; set; }

        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        public int type { get; set; }

        public string message { get; set; }

        public CheckOutModel(Database database)
        {
            db = database;
        }
        public void OnGet()
        {

            type = db.returnType(UserName);


        }
    }
}
