using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using SMARTLY.Pages.Models;
using System.Data;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace SMARTLY.Pages
{
    public class EditAgencyModel : PageModel
    {
        private readonly Database db;
       
        public DataTable dt { get; set; }

        [BindProperty]
        public Agency agency { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]

        public string username {  get; set; }
       
        public EditAgencyModel(Database database)
        {
            db = database;
        }
        public void OnGet(string email)
        {
          
            username = db.returnUsername(email);

            dt =(DataTable) db.return_info(username);
           



        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                db.UpdateAllAgencies(agency, username);

                return RedirectToPage("/All_Agencies");
            }
            else
            {
                return Page();
            }
        }

    }
}
