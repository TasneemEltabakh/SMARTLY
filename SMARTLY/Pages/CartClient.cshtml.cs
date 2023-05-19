using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CartClientModel : UserPageModel
    {
        [BindProperty]
        static public int itemsCount { get; set; } = 0;

        [BindProperty]
        public string id { get; set; }

        private readonly Database data;

        public DataTable dt { get; set; }

        [BindProperty]
        public DataTable carttable { get; set; }

        public CartClientModel(Database database)
        {
            this.data = database;
        }
        public void OnGet(string id)
        {
            this.id = id;
            data.AddProductToCart(UserName, id);
            carttable= data.ReadCart(UserName);
        }
        public DataTable returnrecordofproduct(int id)
        {
            dt= data.ReadProductRow(id);
            return dt;
        }
        public string returnCategory(int id)
        {
            string title = data.getTitleCategory(id);
            return title;
        }
    }
}
