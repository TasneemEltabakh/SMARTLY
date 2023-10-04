namespace SMARTLY.Pages.Models
{
	public class BundleProducts
	{
		public int Id { get; set; }
		public int quantity { get; set; }
		public BundleProducts(int id, int quantity)
		{
			Id = id;
			this.quantity = quantity;
		}	
	}
}
