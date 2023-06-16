using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    
    public class UserPageModel : PageModel
    {
        
        public string UserName { get; set; }
        public int ThisState { get; set; }
   
        public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
        {
            UserName = HttpContext.Session.GetString("UserName");
            ThisState = (int)(HttpContext.Session.GetInt32("State") ?? 0);

            base.OnPageHandlerExecuting(context);
        }
    }
}

