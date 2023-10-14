using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System;
using System.Data;

namespace SMARTLY.Pages
{
	public class CartClientModel : UserPageModel
	{
		private readonly Database data;

		public DataTable dt { get; set; }
		public DataTable db { get; set; }
		[BindProperty]
		public int itemsCount { get; set; }

		[BindProperty]
		public string Shipp { get; set; }

		[BindProperty]
		public string id { get; set; }

		[BindProperty]
		public string? DeletedId { get; set; } = null;

		public DataTable products { get; set; }

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
		public long totalPrice { get; set; } = 0;
		[BindProperty]
		public int usertype { get; set; }


		[BindProperty]
		public List<ProductsCart> ProductsCart { get; set; }
		[BindProperty]

		public ProductsCart p { set; get; }
		public string shipping { get; set; }

		public CartClientModel(Database database)
		{
			this.data = database;
			quantity = 1;
			shipping = "5";
		}
		public void OnGet()
		{
			usertype = data.returnType(UserName);
			string deleted = Request.Query["Deleted"];
			string id = Request.Query["id"];
			string type = Request.Query["type"];
			string typing = Request.Query["TYPES"];
			summary = Request.Query["quantity"];
			if (usertype == 3)
			{
				itemsCount = data.TotalItem(UserName);
			}
			else
			{
				itemsCount = data.TotalItemGuest(UserName);
			}
			
			Shipp = Request.Query["shippin"];
			if (!string.IsNullOrEmpty(deleted) && !string.IsNullOrEmpty(type))
			{
				if (usertype==3)
				{
					carttable = data.Deletefromcart(Convert.ToInt32(deleted), UserName, Convert.ToInt32(type));
					ProductsCart = new List<ProductsCart>();
					itemsCount = data.TotalItem(UserName);
				}
				else
				{
					carttable = data.DeletefromcartGuest(Convert.ToInt32(deleted), UserName, Convert.ToInt32(type));
					ProductsCart = new List<ProductsCart>();
					itemsCount = data.TotalItemGuest(UserName);
				}
			

				for (int i = 0; i < carttable.Rows.Count; i++)
				{
					int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
					if (Quantity > 0)
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE= Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);

					}
					else
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) ,TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);
					}

				}

			}
			else
			{
				if (usertype == 3)
				{
					carttable = data.ReadCart(UserName);
					ProductsCart = new List<ProductsCart>();
					itemsCount = data.TotalItem(UserName);
				}
				else
				{
					carttable = data.ReadCartGuest(UserName);
					ProductsCart = new List<ProductsCart>();
					itemsCount = data.TotalItemGuest(UserName);
				}
				
				for (int i = 0; i < carttable.Rows.Count; i++)
				{

					int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
					if (Quantity > 0)
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]), TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);

					}
					else
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);
					}

				}

			}
			if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(summary) && !string.IsNullOrEmpty(typing))
			{
				for (int i = 0; i < carttable.Rows.Count; i++)
				{
					if (int.TryParse(id, out int productId) && int.TryParse(summary, out int newQuantity) && int.TryParse(typing, out int types)&& Convert.ToInt32(carttable.Rows[i][1]) == productId && Convert.ToInt32(carttable.Rows[i][4])==types)
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
							if (usertype == 3)
							{
								data.UpdateCart(id, newQuantity, UserName, shipping, types);
							}
							else
							{
								data.UpdateCartGuest(id, newQuantity, UserName, shipping, types);
							}

							
						}
						else
						{
							if (usertype == 3)
							{
								data.UpdateCart(id, newQuantity, UserName, Shipp, types);
							}
							else
							{
								data.UpdateCartGuest(id, newQuantity, UserName, Shipp, types);
							}
							
						}
						if (usertype == 3)
						{
							carttable = data.ReadCart(UserName);
							itemsCount = data.TotalItem(UserName);
						}
						else
						{
							carttable = data.ReadCartGuest(UserName);
							itemsCount = data.TotalItemGuest(UserName);
						}
						


					}
				}
			}

		}
		public void OnGetAdd(string id, string type)
		{
			usertype = data.returnType(UserName);
			string deleted = Request.Query["Deleted"];
			string typer = Request.Query["type"];
			string typing = Request.Query["TYPES"];
			string idd = Request.Query["id"];
			summary = Request.Query["quantity"];
			Shipp = Request.Query["shippin"];
			if (usertype == 3)
			{
				itemsCount = data.TotalItem(UserName);
			}
			else
			{
				itemsCount = data.TotalItemGuest(UserName);
			}

			if (!string.IsNullOrEmpty(deleted) && !string.IsNullOrEmpty(typer))
			{
				if (usertype == 3)
				{
					carttable = data.Deletefromcart(Convert.ToInt32(deleted), UserName, Convert.ToInt32(typer));
					calcTotal();
					itemsCount = data.TotalItem(UserName);
				}
				else
				{
					carttable = data.DeletefromcartGuest(Convert.ToInt32(deleted), UserName, Convert.ToInt32(typer));
					calcTotal();
					itemsCount = data.TotalItemGuest(UserName);
				}

				

				ProductsCart = new List<ProductsCart>();
				for (int i = 0; i < carttable.Rows.Count; i++)
				{
					int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
					if (Quantity > 0)
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);

					}
					else
					{
						ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
						ProductsCart.Add(product);
					}

				}
			}
			else
			{
				this.id = id;

				if (Convert.ToInt32(type) == 1)
				{
					if (string.IsNullOrEmpty(Shipp))
					{
						if (usertype == 3)
						{
							data.AddProductToCart(UserName, id, quantity, shipping, 1);
							itemsCount = data.TotalItem(UserName);

							carttable = data.ReadCart(UserName);
							calcTotal();
						}
						else
						{
							data.AddProductToCartGuest(UserName, id, quantity, shipping, 1);
							itemsCount = data.TotalItemGuest(UserName);

							carttable = data.ReadCartGuest(UserName);
							calcTotal();
						}
						
					}
					else
					{
						if (usertype == 3)
						{
							data.AddProductToCart(UserName, id, quantity, Shipp, 1);
							itemsCount = data.TotalItem(UserName);

							carttable = data.ReadCart(UserName);
							calcTotal();
						}
						else
						{
							data.AddProductToCartGuest(UserName, id, quantity, Shipp, 1);
							itemsCount = data.TotalItemGuest(UserName);

							carttable = data.ReadCartGuest(UserName);
							calcTotal();
						}
						
					}

					

					ProductsCart = new List<ProductsCart>();
					for (int i = 0; i < carttable.Rows.Count; i++)
					{

						int Quantity = Convert.ToInt32(carttable.Rows[i][2]);
						if (Quantity > 0)
						{
							ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
							ProductsCart.Add(product);

						}
						else
						{
							ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[i][1]) , TYPE = Convert.ToInt32(carttable.Rows[i][4]) };
							ProductsCart.Add(product);
						}

					}
				}
				if (Convert.ToInt32(type) == 2)
				{

					if (string.IsNullOrEmpty(Shipp))
					{
						if (usertype == 3)
						{
							data.AddProductToCart(UserName, id, quantity, shipping, 2);
							itemsCount = data.TotalItem(UserName);

							carttable = data.ReadCart(UserName);
							calcTotal();
						}
						else
						{
							data.AddProductToCartGuest(UserName, id, quantity, shipping, 2);
							itemsCount = data.TotalItemGuest(UserName);

							carttable = data.ReadCartGuest(UserName);
							calcTotal();
						}
						
					}
					else
					{
						if (usertype == 3)
						{
							data.AddProductToCart(UserName, id, quantity, Shipp, 2);
							itemsCount = data.TotalItem(UserName);

							carttable = data.ReadCart(UserName);
							calcTotal();
						}
						else
						{
							data.AddProductToCartGuest(UserName, id, quantity, Shipp, 2);
							itemsCount = data.TotalItemGuest(UserName);

							carttable = data.ReadCartGuest(UserName);
							calcTotal();
						}

					}

					

					ProductsCart = new List<ProductsCart>();
					for (int j = 0; j < carttable.Rows.Count; j++)
					{

						int Quantity = Convert.ToInt32(carttable.Rows[j][2]);
						if (Quantity > 0)
						{
							ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = Quantity, Id = Convert.ToInt32(carttable.Rows[j][1]), TYPE = Convert.ToInt32(carttable.Rows[j][4]) };
							ProductsCart.Add(product);

						}
						else
						{
							ProductsCart product = new ProductsCart { UserName = this.UserName, quantity = 1, Id = Convert.ToInt32(carttable.Rows[j][1]), TYPE = Convert.ToInt32(carttable.Rows[j][4]) };
							ProductsCart.Add(product);
						}

					}


				}
			}
			
			if (!string.IsNullOrEmpty(idd) && !string.IsNullOrEmpty(summary) && !string.IsNullOrEmpty(typing))
			{
				for (int i = 0; i < carttable.Rows.Count; i++)
				{
					if (int.TryParse(idd, out int productId) && int.TryParse(summary, out int newQuantity) && int.TryParse(typing, out int types) && Convert.ToInt32(carttable.Rows[i][1]) == productId && Convert.ToInt32(carttable.Rows[i][4]) == types)
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
							if (usertype == 3)
							{
								data.UpdateCart(idd, newQuantity, UserName, shipping, types);
								itemsCount = data.TotalItem(UserName);

								carttable = data.ReadCart(UserName);
								calcTotal();
							}
							else
							{
								data.UpdateCartGuest(idd, newQuantity, UserName, shipping, types);
								itemsCount = data.TotalItemGuest(UserName);

								carttable = data.ReadCartGuest(UserName);
								calcTotal();
							}
							
						}
						else
						{

							if (usertype == 3)
							{
								data.UpdateCart(idd, newQuantity, UserName, Shipp, types);
								itemsCount = data.TotalItem(UserName);

								carttable = data.ReadCart(UserName);
								calcTotal();
							}
							else
							{
								data.UpdateCartGuest(idd, newQuantity, UserName, Shipp, types);
								itemsCount = data.TotalItemGuest(UserName);

								carttable = data.ReadCartGuest(UserName);
								calcTotal();
							}
							
						}

						

					}
				}
			}
		}
		public DataTable returnrecordofproduct(int id, int type)
		{
			if (type == 1)
			{
				dt = data.ReadProductRow(id);
			}
			if (type == 2)
			{
				dt = data.ProductsOfBundleCart(id);
			}

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

		public long calcTotal()
		{
			long x = 0;

			for (int i = 0; i < carttable.Rows.Count; i++)
			{
				if (Convert.ToInt32(carttable.Rows[i][4]) == 1)
				{
					DataTable t = data.ReadProductRow(Convert.ToInt32(carttable.Rows[i][1]));
					x = (Convert.ToInt64(t.Rows[0][9]) * Convert.ToInt64(carttable.Rows[i][2])) + x;
				}
				else
				{
					DataTable t = data.ProductsOfBundleCart(Convert.ToInt32(carttable.Rows[i][1]));
					x = (Convert.ToInt64(t.Rows[0][0]) * Convert.ToInt64(carttable.Rows[i][2])) + x;
				}
			}
			totalPrice = x + Convert.ToInt64(Shipp);
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