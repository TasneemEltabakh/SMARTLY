using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class SignUpModel : UserPageModel
    {
        private readonly Database database;
        private readonly IHttpContextAccessor httpContextAccessor;


        [BindProperty]
        public User user { get; set; }

        [BindProperty]
        public Client client { get; set; }

        [BindProperty]
        public string passwordcheck { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool state { get; set; }
        public int val { get; set; }
        public string msg { get; set; }

        public SignUpModel(Database db, IHttpContextAccessor httpContextAccessor)
        {
            this.database = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
            msg = "free";
			int guestID = database.maxGuestID();
			UserName = Convert.ToString(guestID);
			database.AddGuest(guestID);

			database.DeleteoldGuest();

			HttpContext.Session.SetString("UserName", UserName);
			HttpContext.Session.SetString("getUserType", "0");

		}
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                if (String.Equals(passwordcheck, user.password))
                {
                    msg = "free";
                    HttpContext.Session.SetString("UserName", user.UserName);
                    HttpContext.Session.SetString("getUserType", "3");

                    database.SignUpNewMember(user, client);
                    return RedirectToPage("/IndexClient");
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
