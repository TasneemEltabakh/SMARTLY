using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class Client
    {
     
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Phone]
        public string phonenumber { get; set; }
    }
}
