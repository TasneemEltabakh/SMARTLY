using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Contact_Us_AdminModel : PageModel
    {
        private readonly Database db;

        [BindProperty]
        public DataTable dt { get; set; }

        public Contact_Us_AdminModel(Database db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            dt = db.loadTableofContact();
        }
    }
}
