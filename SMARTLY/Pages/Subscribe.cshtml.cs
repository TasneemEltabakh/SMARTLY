using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class SubscribeModel : PageModel
    {
        private readonly Database database;

        public string Email { get; set; }

        public SubscribeModel(Database database)
        {
            this.database = database;
            Email = "lolo";
        }

     
     

        public IActionResult OnPost()
        {
            
        
            database.insertSubscribe(Email);

          
            return RedirectToPage("/Index");
        }
    }
}
