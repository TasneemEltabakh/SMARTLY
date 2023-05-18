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


        public string Email { get; set; }
        public DeleteAgencyModel(Database database)
        {
            db = database;
        }
        public void OnGet(string email)
        {

            dt =(DataTable) db.return_info(email);

        }
        public void OnPost()
        {

        }

    }
}

