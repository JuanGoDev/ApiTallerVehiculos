using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class ImagenVehiculoDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FotoVehiculo { get; set; }
    }
}
