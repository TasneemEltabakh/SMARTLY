using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SMARTLY.Pages
{
    public class IndexClientModel : UserPageModel
    {
        private readonly ILogger<IndexModel> _logger;
      

        [BindProperty(SupportsGet = true)]
        public int type { get; set; }


        public IndexClientModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
