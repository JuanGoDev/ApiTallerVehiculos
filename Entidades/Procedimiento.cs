using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TallerVehiculos.Entidades
{
    public class Procedimiento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripción { get; set; }
        [Required]
        public int HorasInvertidas { get; set; }
        [Required]
        public int ValorProcedimiento { get; set; }
        [JsonIgnore]
        public ICollection<DetalleHistorial> DetalleHistoriales { get; set; }

    }
}