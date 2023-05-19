using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CartClientModel : UserPageModel
    {
        [BindProperty]
        public int itemsCount { get; set; } = 0;

        [BindProperty]
        public int id { get; set; }

        private readonly Database data;
        public DataTable dt { get; set; }

        public DataTable carttable { get; set; }

        public CartClientModel(Database database)
        {
            this.data = database;
        }

        public void OnGet(int id)
        {
            string userName = UserName;
            // Use the 'userName' variable as needed
        }
    }
}