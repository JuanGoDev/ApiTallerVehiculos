using System.ComponentModel.DataAnnotations;
using TallerVehiculos.Entidades;
using TallerVehiculos.Models;

namespace TallerVehiculos.DTOs
{
    public class HistorialDTO
    {
        public int Id { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string IdUsuario { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public IdentityModels IdentityModels { get; set; }
        [Required]
        public int TiempoInvertido { get; set; }
    }
}
