using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Entidades;
using TallerVehiculos.Models;

namespace TallerVehiculos.DTOs
{
    public class HistorialCreacionDTO
    {
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
    }
}
