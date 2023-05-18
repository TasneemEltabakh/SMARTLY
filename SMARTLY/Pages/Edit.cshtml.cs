using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using SMARTLY.Pages.Models;
using System.Data;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace SMARTLY.Pages
{
    public class EditModel : PageModel
    {
        private readonly Database db;
        [BindProperty]
        public DataTable dt { get; set; }   
        [BindProperty]
        public Agency agency { get; set; }

        [BindProperty(SupportsGet =true)]
         public int email { get; set; }
        public void OnGet()
        {
           
          
           
        }
        public void OnPost()
        {
        }

    }
}
