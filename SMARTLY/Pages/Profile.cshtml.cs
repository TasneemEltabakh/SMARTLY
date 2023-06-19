using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;

namespace SMARTLY.Pages
{
    public class ProfileModel : UserPageModel
    {
        private readonly Database Db;
        public DataTable dt { get; set; }
        [BindProperty]
        public List<IFormFile> Image123 { get; set; }
        [BindProperty]
        public byte[] Pimage123 { get; set; }
        [BindProperty]
        public DataTable userData { get; set; }


        [BindProperty]
        public DataTable ProductsTable { get; set; }

        [BindProperty]

        public string password { get; set; }
        [BindProperty]

        public string passwordencryped { get; set; }

        [BindProperty]
        public int isedit { set; get; }
        public ProfileModel(Database db, IHttpContextAccessor httpContextAccessor)
        {
            Db = db;
            var state = httpContextAccessor.HttpContext?.Session.GetInt32("State");
            isedit = state ?? 0;
        }
        public void OnGet()
        {
            userData = Db.ReadUser(UserName);
            if (userData.Rows.Count > 0)
            {
                password = Convert.ToString(userData.Rows[0][1]);
                passwordencryped = new string('*', password.Length);

            }
        }
        public IActionResult OnPost()
        {
            if (this.isedit == 0)
            {
                this.isedit = 1;
            }
            else
            {
                this.isedit = 0;
            }
            HttpContext.Session.SetInt32("State", this.isedit);
            return RedirectToPage("/IndexAdmin", new { UserName = this.UserName, ThisState = this.isedit });
        }
        public async Task<IActionResult> OnPostAdd()
        {
            
            foreach (var item in Image123)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        Pimage123 = stream.ToArray();
                    }
                }
            }
            if (ModelState.IsValid)
            {
                Db.AddImgNewUser(Pimage123);
                return RedirectToPage("/IndexAdmin");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
    
}
