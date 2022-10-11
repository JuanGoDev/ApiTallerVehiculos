using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.DTOs
{
    public class TipoDocumentoCreacionDTO
    {        
        [Required]
        public string Tipo { get; set; }
        [Required]
        public DateTime FechaExpedicion { get; set; }
        [Required]
        [StringLength(20)]
        public string DepartamentoNacimiento { get; set; }
        [Required]
        [StringLength(20)]
        public string CiudadNacimiento { get; set; }
    }
}
