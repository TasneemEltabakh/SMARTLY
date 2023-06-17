using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Add_New_ProductModel : UserPageModel
    {
        private readonly Database data;

        [BindProperty]
        public Product product { get; set; }

        [BindProperty]
        public List<IFormFile> Image123 { get; set; }
        public Add_New_ProductModel(Database db) {
            data = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            //if (ModelState.IsValid)
            //{
                foreach (var item in Image123)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            product.Pimage = stream.ToArray();
                        }
                    }
                }
                product.PId = data.GetMaxProductId();
                data.AddNewProduct(product);
                return RedirectToPage("/Products_Main_Admin");
            //}
            //else
            //{
                //return Page();
            //}
        }
    }
}
