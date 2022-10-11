using System.ComponentModel.DataAnnotations;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.DTOs
{
    public class DetalleHistorialCreacionDTO
    {
        public int IdHistorial { get; set; }
        public int IdProcedimiento { get; set; }
        public Historial Historial { get; set; }
        public Procedimiento Procedimiento { get; set; }
        [Required]
        public DateTime FechaReporte { get; set; }
        [StringLength(50)]
        [Required]
        public string Observaciones { get; set; }
    }
}
