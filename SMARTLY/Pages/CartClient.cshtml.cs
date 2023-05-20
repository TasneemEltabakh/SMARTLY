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
        public string id { get; set; }

        [BindProperty]
        public string? DeletedId { get; set; } = null;


        private readonly Database data;

        public DataTable dt { get; set; }

    

        [BindProperty]
        public DataTable carttable { get; set; }

        public double summary { get; set; }

        [BindProperty]
        public int quantity { get; set; }

        [BindProperty]
        public int idproduct { get; set; }

        [BindProperty]
        public double productprice { get; set; }

        public double shipping { get; set; }

        public CartClientModel(Database database)
        {
            this.data = database;
            quantity = 1;
        }

        public void OnGet()
        {
            DeletedId = null;
            carttable = data.ReadCart(UserName);
            shipping = 5;
           
        }


        public void OnGetAdd(string id)
        {
        
            this.id = id;
            data.AddProductToCart(UserName, id, quantity);
            carttable = data.ReadCart(UserName);
            shipping = 5;
            

        }
       
        public DataTable returnrecordofproduct(int id)
        {
            dt = data.ReadProductRow(id);
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
                    


            data.UpdateCart(id, quantity);

           
           

          
        }
    }
}



