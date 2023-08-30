using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class CartModel : UserPageModel
    {
        private readonly Database data;

        public DataTable dt { get; set; }
        [BindProperty]
        public int itemsCount { get; set; }

        [BindProperty]
        public string Shipp { get; set; }

        [BindProperty]
        public string id { get; set; }

        [BindProperty]
        public string? DeletedId { get; set; } = null;



        [BindProperty]
        public DataTable carttable { get; set; }

        public string summary { get; set; }

        [BindProperty]
        public int quantity { get; set; }

        [BindProperty]
        public int idproduct { get; set; }

        [BindProperty]

        public double productprice { get; set; }

        [BindProperty]
        public int Deleted { get; set; }
        [BindProperty]
        public int totalPrice { get; set; } = 0;


        [BindProperty]
        public List<ProductsCart> ProductsCart { get; set; }
        [BindProperty]

        public ProductsCart p { set; get; }
        public string shipping { get; set; }

        public CartModel(Database database)
        {
            this.data = database;
            quantity = 1;
            shipping = "5";

        }

        public void OnGet()
        {
            string deleted = Request.Query["Deleted"];
            string id = Request.Query["id"];
            summary = Request.Query["quantity"];
            itemsCount = data.TotalItemGuest(UserName);
            Shipp = Request.Query["shippin"];


            if (!string.IsNullOrEmpty(deleted))
            {
                carttable = data.DeletefromcartGuest(Convert.ToInt32(deleted), UserName);
                ProductsCart = new List<ProductsCart>();
                itemsCount = data.TotalItemGuest(UserName);

                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
                    if (Quantity > 0)
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);

                    }
                    else
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);
                    }

                }

            }
            else
            {
                carttable = data.ReadCartGuest(UserName);
                ProductsCart = new List<ProductsCart>();
                itemsCount = data.TotalItemGuest(UserName);

                for (int i = 0; i < carttable.Rows.Count; i++)
                {

                    int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
                    if (Quantity > 0)
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);

                    }
                    else
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);
                    }

                }

            }
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(summary))
            {
                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    if (int.TryParse(id, out int productId) && int.TryParse(summary, out int newQuantity) && Convert.ToInt32(carttable.Rows[i][1]) == productId)
                    {
                        foreach (var product in ProductsCart)
                        {
                            if (product.Id == productId)
                            {
                                product.quantity = newQuantity;
                            }
                        }
                        if (string.IsNullOrEmpty(Shipp))
                        {
                            data.UpdateCartGuest(id, newQuantity, UserName, shipping);
                        }
                        else
                        {
                            data.UpdateCartGuest(id, newQuantity, UserName, Shipp);
                        }

                        carttable = data.ReadCartGuest(UserName);
                        itemsCount = data.TotalItemGuest(UserName);


                    }
                }
            }

        }
        public void OnGetAdd(string id)
        {
            string deleted = Request.Query["Deleted"];
            string idd = Request.Query["id"];
            summary = Request.Query["quantity"];
            Shipp = Request.Query["shippin"];
            itemsCount = data.TotalItemGuest(UserName);


            if (!string.IsNullOrEmpty(deleted))
            {
                carttable = data.DeletefromcartGuest(Convert.ToInt32(deleted), UserName);
                calcTotal();
                itemsCount = data.TotalItemGuest(UserName);

                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i < carttable.Rows.Count; i++)
                {

                    int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
                    if (Quantity > 0)
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);

                    }
                    else
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);
                    }

                }
            }
            else
            {
                this.id = id;
                if (string.IsNullOrEmpty(Shipp))
                {
                    data.AddProductToCartGuest(UserName, id, quantity, shipping);
                }
                else
                {
                    data.AddProductToCartGuest(UserName, id, quantity, Shipp);
                }

                itemsCount = data.TotalItemGuest(UserName);

                carttable = data.ReadCartGuest(UserName);
                calcTotal();

                ProductsCart = new List<ProductsCart>();
                for (int i = 0; i < carttable.Rows.Count; i++)
                {

                    int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
                    if (Quantity > 0)
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);

                    }
                    else
                    {
                        ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) };
                        ProductsCart.Add(product);
                    }

                }

            }
            if (!string.IsNullOrEmpty(idd) && !string.IsNullOrEmpty(summary))
            {
                for (int i = 0; i < carttable.Rows.Count; i++)
                {
                    if (int.TryParse(idd, out int productId) && int.TryParse(summary, out int newQuantity) && Convert.ToInt32(carttable.Rows[i][1]) == productId)
                    {
                        foreach (var product in ProductsCart)
                        {
                            if (product.Id == productId)
                            {
                                product.quantity = newQuantity;
                            }
                        }
                        if (string.IsNullOrEmpty(Shipp))
                        {
                            data.UpdateCartGuest(idd, newQuantity, UserName, shipping);
                        }
                        else
                        {
                            data.UpdateCartGuest(idd, newQuantity, UserName, Shipp);
                        }

                        carttable = data.ReadCartGuest(UserName);
                        itemsCount = data.TotalItemGuest(UserName);

                    }
                }
            }




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

        public IActionResult OnPost()
        {
            return RedirectToPage("/CheckOut");
        }
        public string returnPrice(int id)
        {
            DataTable t = data.ReadProductRow(id);
            string name = Convert.ToString(t.Rows[0][2]);
            return name;
        }

        public int calcTotal()
        {
            int x = 0;
            for (int i = 0; i < carttable.Rows.Count; i++)
            {

                DataTable t = data.ReadProductRow(Convert.ToInt32(carttable.Rows[i][1]));
                x = (Convert.ToInt32(t.Rows[0][9]) * Convert.ToInt32(carttable.Rows[i][2])) + x;

            }
            totalPrice = x + Convert.ToInt32(Shipp);
            return totalPrice;



        }
        public IActionResult OnPostProceed()
        {
            totalPrice = calcTotal();

            Console.WriteLine($"Shipping : {Shipp},  price: {totalPrice}");
            return RedirectToPage("/CheckOut", new
            {
                shippingFees = this.Shipp,

            });


        }


    }
}

