using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class LogInModel : PageModel
    {
        private readonly Database database;

        [BindProperty]
        public User user { get; set; }
        public string message { get; set; }

        public int Type { get; set; }
        public LogInModel(Database db)
        {
            this.database = db;
        }
        public void OnGet()
        {
            message = "free";
        }
        public IActionResult OnPost()
        {
            if (!database.checkemail(user.UserName))
            {
                message = "Your Username isn't register";
                return Page();
            }
            else
            {
                if (!database.CheckPassword(user.password, user.UserName))
                {
                    message = "Wrong password";
                    return Page();
                }
                else
                {
                    message = "free";
                    if ((database.returnType(user.UserName) != 1) && (database.returnType(user.UserName) != 2) && (database.returnType(user.UserName) != 3))
                    {
                        message = "hererero";
                        return Page();
                    }
                    else
                    {
                        message = "free";
                        Type = database.returnType(user.UserName);
                        return RedirectToPage("/Index", new { UserName = user.UserName, type = Type });
                    }



                }
            }


        }
    }
}
