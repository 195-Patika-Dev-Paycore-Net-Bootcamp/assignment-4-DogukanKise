using Dto.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Dto.Concrete
{
    public class ContainerDto : IDto
    {
        // Dto class for the Container and with some attributes
        [Required]
        [Display(Name = "ID")]
        public long id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [Display(Name = "Container Name")]
        public string container_name { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double longitude { get; set; }

        [Required]
        [Display(Name = "Vehicle Id")]
        public long vehicle_id { get; set; }
    }
}
