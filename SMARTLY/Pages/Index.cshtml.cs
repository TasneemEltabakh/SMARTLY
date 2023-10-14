using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class IndexModel : UserPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Database db;
        private DateTime lastDeleteTime = DateTime.MinValue;

        [BindProperty(SupportsGet = true)]
        public int type { get; set; }
       

        public IndexModel(ILogger<IndexModel> logger,Database database)
        {
            _logger = logger;
            db = database;
        }

        public void OnGet()
        {
            int guestID = db.maxGuestID();
            UserName = Convert.ToString(guestID);
            db.AddGuest(guestID+1);
            db.DeleteoldGuest();
            HttpContext.Session.SetString("UserName", UserName);
            HttpContext.Session.SetString("getUserType", "0");
        }
    }
}