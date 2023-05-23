using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class ProfileModel : UserPageModel
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

        [BindProperty]
        public bool isedit { set; get; }
        public ProfileModel(Database db)
        {
            Db = db;
            isedit = false;
        }
        public void OnGet()
        {
            userData = Db.ReadUser(UserName);
            password = Convert.ToString(userData.Rows[0][1]);
            passwordencryped = new string('*', password.Length);
        }
    }
    
}
