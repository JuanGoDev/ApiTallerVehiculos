using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class MarcaCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Procedencia { get; set; }
    }
}
