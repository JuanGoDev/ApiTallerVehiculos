using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TallerVehiculos.Entidades
{
    public class ImagenVehiculo
    {
        public int Id { get; set; }
        public int Placa { get; set; }
        [JsonIgnore]
        public Vehiculo Vehiculo { get; set; }
        [Required]
        [StringLength(50)]
        public string FotoVehiculo { get; set; }
    }
}
