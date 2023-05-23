using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class ProfileClientModel : UserPageModel
    {
        private readonly Database Db;
        public DataTable dt { get; set; }

        [BindProperty]
        public DataTable userData { get; set; }


        [BindProperty]
        public DataTable ProductsTable { get; set; }

        [BindProperty]

        public string password { get; set; }
        [BindProperty]

        public string passwordencryped { get; set; }
        public ProfileClientModel(Database db)
        {
            Db = db;
        }
        public void OnGet()
        {
            userData = Db.ReadUser(UserName);
            password = Convert.ToString(userData.Rows[0][1]);

            passwordencryped = new string('*', password.Length);
        }
    }
}

