using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
namespace SMARTLY.Pages
{
    public class Contact_UsModel : UserPageModel
    {

        private readonly Database db;
        [BindProperty]
        public Contact_Us contactcs { get; set; }
        public string msg { get; set; }

        public Contact_UsModel(Database db)
        {
            this.db = db; 
        }
        public void OnGet()
        {
            msg = "free";
           
        }
        public void OnPost()
        {
 
            if (ModelState.IsValid)
            {

                db.Insert_Contact(contactcs);
                msg = "Recived sucessfully ";

            }
            else
            {
                msg = "free";
                
            }
                

		}
    }
}
