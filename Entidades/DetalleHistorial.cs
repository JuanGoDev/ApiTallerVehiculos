using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TallerVehiculos.Entidades
{
    public class DetalleHistorial
    {
        public int Id { get; set; }
        public int IdHistorial { get; set; }
        public int IdProcedimiento { get; set; }
        [JsonIgnore]
        public Historial Historial { get; set; }
        [JsonIgnore]
        public Procedimiento Procedimiento { get; set; }
        [Required]
        public DateTime FechaReporte { get; set; }
        [StringLength(50)]
        [Required]
        public string Observaciones { get; set; }
    }
}
