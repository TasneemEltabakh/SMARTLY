using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly Database database;

        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public Client client { get; set; }

        [BindProperty]
        public string passwordcheck { get; set; }
        
        public string msg { get; set; }
        public SignUpModel(Database db)
        {
            this.database = db;
        }
        public void OnGet()
        {
            msg = "free";
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (String.Equals(passwordcheck, user.password))
                {
                    msg = "free";
                    user.usertype = 3;
                    database.SignUpNewMember(user, client);
                    return RedirectToPage("/Index", new { UserName = user.UserName, type = 3 });
                }
                else

                {
                    msg = "Passwords don't match";
                    return Page();
                }
            }
            else return Page();
        }
    }
}
