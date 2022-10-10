using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Entidades
{
    public class TipoDocumento
    {
        public int Id { get; set; }
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
