using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class ProcedimientoCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string Descripción { get; set; }
        [Required]
        public int HorasInvertidas { get; set; }
        [Required]
        public int ValorProcedimiento { get; set; }
    }
}
