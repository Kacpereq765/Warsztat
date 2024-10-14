using System.ComponentModel.DataAnnotations;

namespace warsztat.Models
{
    public class Car
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; } = string.Empty;

        [Range(1886, 2100, ErrorMessage = "Year must be between 1886 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "IsBroken is required.")]
        public bool IsBroken { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
    }
}
