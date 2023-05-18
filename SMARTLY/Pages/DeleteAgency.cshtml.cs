using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteAgencyModel : PageModel
    {
        private readonly Database db;

        public DataTable dt { get; set; }

        [BindProperty]
        public Agency agency { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]

        public string username { get; set; }

        public DeleteAgencyModel(Database database)
        {
            db = database;
        }
        public void OnGet(string email)
        {

            username = db.returnUsername(email);

        }
        public IActionResult OnPost()
        {
            db.Deletedrecord(username);
           return RedirectToPage("/All_Agencies");
        }

    }
}

