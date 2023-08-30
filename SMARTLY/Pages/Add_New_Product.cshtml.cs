using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class Add_New_ProductModel : UserPageModel
    {
        private readonly Database data;
        [BindProperty]
        public DataTable dtt { get; set; }
        [BindProperty]
        public int category { get; set; }
        [BindProperty]
        public Product product { get; set; }

        [BindProperty]
        public List<IFormFile> Image123 { get; set; }

        [BindProperty]
        public List<IFormFile> Image111 { get; set; }
        [BindProperty]
        public byte[] Pimage11 { get; set; }
        [BindProperty]
        public List<IFormFile> Image222 { get; set; }
        [BindProperty]
        public byte[] Pimage22 { get; set; }
        [BindProperty]
        public List<IFormFile> Image333 { get; set; }
        [BindProperty]
        public byte[] Pimage33 { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        public Add_New_ProductModel(Database db) {
            data = db;
        }
        public void OnGet()
        {
           

            dtt = data.ReadCategoryForAddProduct();
        }
       
        public async Task<IActionResult> OnPostAdd()
        {

            if (string.IsNullOrEmpty(Request.Form["category"]))
            {
                product.category = 1;
            }
            else
            {
                int category = Convert.ToInt32(Request.Form["category"]);
                product.category = category;
            }




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
            foreach (var item in Image111)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        Pimage11 = stream.ToArray();
                    }
                }
            }
            foreach (var item in Image222)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        Pimage22 = stream.ToArray();
                    }
                }
            }
            foreach (var item in Image333)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        Pimage33 = stream.ToArray();
                    }
                }
            }
            //if (ModelState.IsValid)
            //{
            

                
            product.PId = data.GetMaxProductId();
            data.AddNewProduct(product);
            data.AddImgNewProduct(product.PId, product.Pimage,1);
            
            data.AddImgNewProduct(product.PId, Pimage11,2);
            
            data.AddImgNewProduct(product.PId, Pimage22,3);
           
            data.AddImgNewProduct(product.PId, Pimage33,4);
          

				return RedirectToPage("/Products_Main_Admin");
           
        }
        
    }
}
