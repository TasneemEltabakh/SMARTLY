using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class AllManagersModel : UserPageModel
    {
        private readonly Database database;
        public DataTable dt { get; set; }

        public AllManagersModel(Database database)
        {
            this.database = database;

        }

        public void OnGet()
        {
            dt = database.loadTableofManagers();
        }

    }
}
