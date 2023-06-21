using System.ComponentModel.DataAnnotations;

namespace SMARTLY.Pages.Models
{
    public class Bundle
    {

        public string BundleId { get; set; }




        public string price { get; set; }




        public int level { get; set; }   //okay for null
        public string Description { get; set; }   //okay for null




        public string Name { get; set; }




        public string img { get; set; }

    }
}
