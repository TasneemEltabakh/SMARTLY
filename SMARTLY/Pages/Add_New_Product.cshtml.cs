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
        public Add_New_ProductModel(Database db) {
            data = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                product.PId = data.GetMaxProductId();
                data.AddNewProduct(product);
                return RedirectToPage("/Products_Main_Admin");
            }
            else
            {
                return Page();
            }
        }
    }
}
