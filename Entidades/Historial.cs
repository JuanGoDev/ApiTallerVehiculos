using System.ComponentModel.DataAnnotations;
using TallerVehiculos.Models;

namespace TallerVehiculos.Entidades
{
    public class Historial
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
