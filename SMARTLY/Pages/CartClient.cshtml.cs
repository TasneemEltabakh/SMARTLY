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


        [BindProperty]
        public string deletedid { get; set; }


        private readonly Database data;

        public DataTable dt { get; set; }

        [BindProperty]
        public DataTable carttable { get; set; }

        public double summary { get; set; }

        [BindProperty]

        public int Quantity { get; set; } = 1;

        [BindProperty]
        public int idproduct { get; set; }

        [BindProperty]
        public double productprice { get; set; }
        public double shipping { get; set; }

        public CartClientModel(Database database)
        {
            this.data = database;

            Quantity = 1;
        }
       
        public IActionResult OnGetDelete(string id)
        {
            // Call the Deletefromcart method to delete the product from the cart
            data.Deletefromcart(id);

            // Refresh the cart data
            carttable = data.ReadCart(UserName);
            shipping = 5;

            // Redirect back to the same page
            return RedirectToPage();
        }
        public void OnGet()
        {

            carttable = data.ReadCart(UserName);
            shipping = 5;
        }
        public void OnGetAdd(string id)
        {
            this.id = id;
            data.AddProductToCart(UserName, id, Quantity);
            carttable = data.ReadCart(UserName);
            shipping = 5;
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
           
       public double setshipping()
        {
            shipping = 0;
            return shipping;
       }

        public void update(int id, int quantity)
        {
            idproduct = id;
            Quantity = quantity;
            data.UpdateCart(idproduct, Quantity);
            carttable = data.ReadCart(UserName);
        }
        

    }

}
