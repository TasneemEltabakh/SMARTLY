using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Add_AgencyModel : UserPageModel
    {
      
        [BindProperty]
        public Agency Agency { get; set; }

        [BindProperty]
        public User user { get; set; }

        private readonly Database database;
        public Add_AgencyModel(Database database)
        {
            this.database = database;
            
        }

        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                user.usertype = 2;
                database.AddNewAgency(user, Agency);
                return RedirectToPage("/All_Agencies");
               
            }
            else
            {
                return Page();
            }
        }
    }
}
