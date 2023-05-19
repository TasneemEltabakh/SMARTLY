using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class Product
    {
        [Required(ErrorMessage = "this field is required")]
        public int PId { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public string PName { get; set; }


        [Required(ErrorMessage = "this field is required")]
        public float price { get; set; }


        public int Quantity { get; set; }   //Okay for null
        public string color { get; set; }   //Okay for null
        public float salePercentage { get; set; }  //Okay for null
        public int category { get; set; }    //Okay for null
        public string AdditionalNotes { get; set; }    //Okay for null
        public string Pimage { get; set; }     //Okay for null
        public float price_aftersale { get; set; }    //Okay for null


    }
}
