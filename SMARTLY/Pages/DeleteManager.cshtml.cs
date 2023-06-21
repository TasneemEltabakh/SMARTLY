using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class DeleteManagerModel : UserPageModel
    {
        private readonly Database db;
        public DataTable dt { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]

        public string username { get; set; }

        public DeleteManagerModel(Database database)
        {
            db = database;
        }
        public void OnGet(string username)
        {

            this.username = username;

        }
        public IActionResult OnPost()
        {
            db.DeletedrecordManager(this.username);
            return RedirectToPage("/AllManager");
        }
    }
}
