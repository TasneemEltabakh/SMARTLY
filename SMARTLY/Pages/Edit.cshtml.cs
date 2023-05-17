using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class EditModel : PageModel
    {
        private readonly Database db;

        [BindProperty]
        public User u { get; set; }
        public void OnGet(string email)
        {

        }
        public void OnPost()
        {
        }

    }
}
