using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    public class Add_New_ProductModel : UserPageModel
    {
        private readonly Database data;
        public int NumberOfExtraImg { get; set; }
        [BindProperty]
        public Product product { get; set; }

        [BindProperty]
        public List<IFormFile> Image123 { get; set; }

        [BindProperty]
        public List<IFormFile> Image333 { get; set; }
        [BindProperty]
        public byte[] Pimage33 { get; set; }

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
            product.PId = data.GetMaxProductId();
                data.AddNewProduct(product);
                data.AddImgNewProduct(product.PId, product.Pimage);
                data.AddImgNewProduct(product.PId, Pimage33);
				return RedirectToPage("/Products_Main_Admin");
            //}
            //else
            //{
                //return Page();
            //}
        }
        public int vv()
        {
            if (NumberOfExtraImg==0)
            {

                NumberOfExtraImg = NumberOfExtraImg + 1;
                return NumberOfExtraImg;

            }
            else
            {
                NumberOfExtraImg = NumberOfExtraImg + 1;
                return NumberOfExtraImg;
            }
        }
    }
}
