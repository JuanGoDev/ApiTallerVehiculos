using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Models;

namespace TallerVehiculos.Entidades
{
    public class Historial
    {
        public int Id { get; set; }
        [Required]
        public int Placa { get; set; }
        [Required]
        public string IdUsuario { get; set; }
        [JsonIgnore]
        public Vehiculo Vehiculo { get; set; }
        [JsonIgnore]
        public IdentityModels IdentityModels { get; set; }
        [Required]
        public int TiempoInvertido { get; set; }
        [JsonIgnore]
        public ICollection<DetalleHistorial> DetalleHistoriales { get; set; }

    }
}
