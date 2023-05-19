using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    
    public class UserPageModel : PageModel
    {
        
        public string UserName { get; set; }

        public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
        {
            UserName = HttpContext.Session.GetString("UserName");
            base.OnPageHandlerExecuting(context);
        }
    }
}

