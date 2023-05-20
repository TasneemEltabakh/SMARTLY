using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
namespace SMARTLY.Pages
{
    public class Contact_UsClientModel : UserPageModel
    {

        private readonly Database db;
        [BindProperty]
        public Contact_Us contactcs { get; set; }
        public string msg { get; set; }

        public Contact_UsClientModel(Database db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            msg = "free";

        }
        public IActionResult OnPost()
        {

            // insert in table contact 
            if (ModelState.IsValid)
            {

                db.Insert_Contact(contactcs);
                return Page(); // is there the eror ? 

            }
            else
                return Page();

        }
    }
}

