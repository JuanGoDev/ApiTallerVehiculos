using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class ImagenVehiculoCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public IFormFile FotoVehiculo { get; set; }
    }
}
