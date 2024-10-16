using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace warsztat.Models
{
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopID { get; set; }

        [Required(ErrorMessage = "Nazwa warsztatu jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa warsztatu nie może przekraczać 100 znaków.")]
        public string NameWorkshop { get; set; }

        [Required(ErrorMessage = "Opis warsztatu jest wymagany.")]
        [StringLength(500, ErrorMessage = "Opis nie może przekraczać 500 znaków.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lokalizacja jest wymagana.")]
        [StringLength(200, ErrorMessage = "Lokalizacja nie może przekraczać 200 znaków.")]
        public string Location { get; set; }
    }
}
