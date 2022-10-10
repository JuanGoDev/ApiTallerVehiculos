using System.ComponentModel.DataAnnotations;
using TallerVehiculos.Models;

namespace TallerVehiculos.Entidades
{
    public class Vehiculo
    {
        [Key]
        public string Placa { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdMarca { get; set; }
        [Required]
        public int IdTipoVehiculo { get; set; }
        [Required]
        public int Kilometros { get; set; }
        [Required]
        [StringLength(50)]
        public string AgenciaTransito { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        public IdentityModels IdentityModels { get; set; }
        public Marca Marca { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
    }
}
