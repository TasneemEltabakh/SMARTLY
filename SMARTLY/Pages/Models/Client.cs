using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class Client
    {

        [Required(ErrorMessage = "this field is required")]
        [EmailAddress(ErrorMessage ="not valid email adress")]
        public string email { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Phone(ErrorMessage ="not a valid phone number")]
       
        
        public string phonenumber { get; set; }
    }
}
