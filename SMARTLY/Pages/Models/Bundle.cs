using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class Bundle
    {
        [Required(ErrorMessage = "this field is required")]

        public string BundleId { get; set; }




        [Required(ErrorMessage = "this field is required")]
        public float price { get; set; }




        public int level { get; set; }   //okay for null
        public string Description { get; set; }   //okay for null




        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }




        [Required(ErrorMessage = "this field is required")]
        public string img { get; set; }

    }
}
