using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Entidades
{
    public class DetalleHistorial
    {
        public int Id { get; set; }
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
