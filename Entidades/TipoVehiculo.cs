using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Entidades
{
    public class TipoVehiculo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }
        [Required]
        public int NumeroPuertas { get; set; }
        [Required]
        public int CantidadPasajeros { get; set; }
    }
}
