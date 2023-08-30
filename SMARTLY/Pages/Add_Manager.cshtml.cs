using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Add_ManagerModel : UserPageModel
    {
        [BindProperty]
        public User user { get; set; }

        private readonly Database database;
        public Add_ManagerModel(Database database)
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
                user.usertype = 4;
                database.AddNewManager(user);
                return RedirectToPage("/AllManager", new { UserName = this.UserName });

            }
            else
            {
                return Page();
            }
        }
    }
}
