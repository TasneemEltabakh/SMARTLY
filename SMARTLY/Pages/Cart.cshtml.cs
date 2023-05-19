using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CartModel : PageModel
    {
        [BindProperty]
        static public int itemsCount { get; set; }= 0;

        [BindProperty]
        public int id { get; set; }

        private readonly Database data;
        public DataTable dt { get; set; }
                
        public CartModel(Database database)
        {
            this.data = database;
        }
        public void OnGet(int id)
        {
            this.id = id;
            dt = data.ReadProductRow(id);
            
        }
  
    }
}
