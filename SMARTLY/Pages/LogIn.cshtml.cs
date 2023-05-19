using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class LogInModel : PageModel
    {
        private readonly Database database;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User user { get; set; }
        public string message { get; set; }

        public int Type { get; set; }
        public LogInModel(Database db, ILogger<IndexModel> logger)
        {
            this.database = db;
            _logger = logger;
        }
        public void OnGet()
        {
            message = "free";
            Type = 0;
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
                        if(Type==1)
                        return RedirectToPage("/IndexAdmin", new { UserName = user.UserName});
                        if (Type == 2)
                            return RedirectToPage("/IndexAgency", new { UserName = user.UserName });
                        if (Type == 3)
                            return RedirectToPage("/IndexClient", new { UserName = user.UserName });
                        else
                            return RedirectToPage("/Index");
                    }



                }
            }


        }
    }
}
