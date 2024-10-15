using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace warsztat.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CarID { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Range(1886, 2100, ErrorMessage = "Year must be between 1886 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "IsBroken is required.")]
        public bool IsBroken { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }
    }
}
