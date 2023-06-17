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

        [BindProperty]
        public int Deleted { get; set; }


        [BindProperty]
        public List<ProductsCart> ProductsCart { get; set; }

       
        public double shipping { get; set; }

        public CartClientModel(Database database)
        {
            this.data = database;
            quantity = 1;
        }

        public void OnGet()
        {
            string deleted = Request.Query["Deleted"]; 

            if (!string.IsNullOrEmpty(deleted))
            {
                carttable = data.Deletefromcart(Convert.ToInt32(deleted), UserName);
                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i< carttable.Rows.Count; i++)
                {
                    ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                    ProductsCart.Add(product);

                }
            }
            else
            {
                carttable = data.ReadCart(UserName);
                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                    ProductsCart.Add(product);

                }

            }
            shipping = 5;
        }
        public void OnGetAdd(string id)
        {
            string deleted = Request.Query["Deleted"]; 

            if (!string.IsNullOrEmpty(deleted))
            {
                carttable = data.Deletefromcart(Convert.ToInt32(deleted), UserName);
                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                    ProductsCart.Add(product);

                }
            }
            else
            {
                this.id = id;
                data.AddProductToCart(UserName, id, quantity);
                carttable = data.ReadCart(UserName);
                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                    ProductsCart.Add(product);

                }

            }
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
        public IActionResult OnPost()
        {
            return RedirectToPage("/CheckOut");
        }
       


    }
}



