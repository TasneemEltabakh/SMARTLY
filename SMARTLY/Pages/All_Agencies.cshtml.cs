using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class All_AgenciesModel : PageModel
    {
        private readonly Database database;
        public DataTable dt { get; set; }

        public All_AgenciesModel(Database database)
        {
            this.database = database;
            dt = database.loadTableofAgencies();

        }

        public void OnGet()
        {

        }

    }
}
