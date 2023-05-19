using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Bundle_Out_AdminModel : PageModel
    {
        public DataTable dt { get; set; }   
        private readonly Database database;

       public Bundle_Out_AdminModel(Database db)
        {
            database = db;
        }
        public void OnGet()
        {
            dt = database.LoadBundlesInfo();
        }
    }
}
