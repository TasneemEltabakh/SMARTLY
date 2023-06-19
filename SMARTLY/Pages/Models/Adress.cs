using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
	public class Adress
	{
        [Required(ErrorMessage = "this field is required")]
        public string Zipcode { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string Street { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string City { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string Floor { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string Flat { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string Buildingno { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string Gov { get; set; }


     
        public string notes { get; set; }


    }
}
