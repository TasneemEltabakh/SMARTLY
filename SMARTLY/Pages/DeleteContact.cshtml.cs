using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteContactModel : UserPageModel
    {
        private readonly Database db;

        public DataTable dt { get; set; }

        [BindProperty]
        public Agency agency { get; set; }

        [BindProperty]
        public int type { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]

        public string username { get; set; }
        [BindProperty]
        public string message { get; set; }

        public DeleteContactModel(Database database)
        {
            db = database;
        }
        public void OnGet(string email, string message)
        {
            type = db.returnType(UserName);
            username = email;
            this.message = message;
        }
        public IActionResult OnPost()
        {
            db.DeletedContact(username, this.message);
            return RedirectToPage("/Contact_Us_Admin");
        }
    }
}
