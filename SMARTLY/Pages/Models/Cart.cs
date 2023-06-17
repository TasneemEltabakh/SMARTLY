namespace SMARTLY.Pages.Models
{
    public class Cart
    {
        
        public string username { get; set; }

        public List<Product> Products { get; set; }

        public void Add_New_ProductModel(int id, int quantity)
        {
            Products = new List<Product>();
        }

    }
}
