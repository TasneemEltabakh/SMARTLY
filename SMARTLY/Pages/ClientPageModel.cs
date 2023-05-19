using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;

namespace SMARTLY.Pages
{
    
    public class ClientPageModel : PageModel
    {
        
        public string UserName { get; set; }

        public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
        {
            
            base.OnPageHandlerExecuting(context);
        }
    }
}

