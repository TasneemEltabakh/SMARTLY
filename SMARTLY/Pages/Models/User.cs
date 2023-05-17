using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class User
    {
        [Required(ErrorMessage ="username is required")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]

        public string password { get; set; }

        public int usertype { get; set; }

    }
}
