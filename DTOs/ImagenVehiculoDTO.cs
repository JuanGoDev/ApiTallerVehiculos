using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.DTOs
{
    public class ImagenVehiculoDTO
    {
        public int Id { get; set; }
        [Required]
        public int Placa { get; set; }
        [JsonIgnore]
        public Vehiculo Vehiculo { get; set; }
        [Required]
        [StringLength(50)]
        public string FotoVehiculo { get; set; }
    }
}
