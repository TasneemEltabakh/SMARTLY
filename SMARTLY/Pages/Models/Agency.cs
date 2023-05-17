using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
	public class Agency
	{
        [Required(ErrorMessage = "this field is required")]
        [EmailAddress(ErrorMessage = "not valid email adress")]
        public string email { get; set; }


        [Required(ErrorMessage ="this field is required")]
       
        public string Name { get; set; }



        [Required(ErrorMessage = "this field is required")]

        public string location { get; set; }



    }
}
