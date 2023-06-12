using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class LogInModel : UserPageModel
    {
        private readonly Database database;
        private readonly IHttpContextAccessor httpContextAccessor;

       

        [BindProperty]
        public User user { get; set; }
        public string message { get; set; }

        [BindProperty(SupportsGet =true)]
        public bool state { get; set; }
        public int val { get; set; }
        public int Type { get; set; }
        public LogInModel(Database db, IHttpContextAccessor accessor)
        {
            this.database = db;
            this.httpContextAccessor = accessor;
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
                        HttpContext.Session.SetString("UserName", user.UserName);
                     
                        message = "free";
                        Type = database.returnType(user.UserName);
                        if(Type==1)
                        return RedirectToPage("/IndexAdmin");
                        if (Type == 2)
                            return RedirectToPage("/IndexAgency");
                        if (Type == 3)
                            return RedirectToPage("/IndexClient");
                        else
                            return RedirectToPage("/Index");
                    }



                }
            }


        }
    }
}
