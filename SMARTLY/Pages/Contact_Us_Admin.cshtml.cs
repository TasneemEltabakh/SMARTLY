using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Contact_Us_AdminModel : UserPageModel
    {
        private readonly Database db;

        [BindProperty]
        public DataTable dt { get; set; }
        [BindProperty]
        public int type { get; set; }
        public Contact_Us_AdminModel(Database db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            type = db.returnType(UserName);
            dt = db.loadTableofContact();
        }
    }
}
