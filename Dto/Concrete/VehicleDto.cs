using Dto.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Dto.Concrete
{
    public class VehicleDto : IDto
    {
        // Dto class for the Vehicle and with some attributes
        [Required]
        [Display(Name = "ID")]
        public long id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [Display(Name = "Vehicle Name")]
        public string vehicle_name { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [Display(Name = "Vehicle Plate")]
        public string vehicle_plate { get; set; }
    }
}
