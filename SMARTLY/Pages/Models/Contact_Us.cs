using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
	public class Contact_Us
	{
		[Required(ErrorMessage = "this field is required")]
		
		public string _Name { get; set; }

		[Required(ErrorMessage = "this field is required")]
		[EmailAddress(ErrorMessage = "not valid email adress")]
		public string Email { get; set; }
		[Required(ErrorMessage = "this field is required")]

		public string _Subject { get; set; }
		[Required(ErrorMessage = "this field is required")]

		public string _Message { get; set; }
	}
}
