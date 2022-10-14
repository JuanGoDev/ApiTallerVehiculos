using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.DTOs
{
    public class ImagenVehiculoCreacionDTO
    {
        [Required]
        public int Placa { get; set; }
        [Required]
        public IFormFile FotoVehiculo { get; set; }
    }
}
