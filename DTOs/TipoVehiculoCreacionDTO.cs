using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class TipoVehiculoCreacionDTO
    {        
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }
        [Required]
        public int NumeroPuertas { get; set; }
        [Required]
        public int CantidadPasajeros { get; set; }
    }
}
