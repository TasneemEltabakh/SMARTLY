using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class DeleteCategoryModel : UserPageModel
    {
        private readonly Database database;


        //[BindProperty]

        static public string PId { get; set; }

        public DeleteCategoryModel(Database db)
        {
            database = db;
        }

        public void OnGet(string id)
        {
            PId = id;
        }
        public IActionResult OnPost()
        {
            database.DeleteCategory(PId);
            return RedirectToPage("/Products_Main_Admin");
        }
    }
}
