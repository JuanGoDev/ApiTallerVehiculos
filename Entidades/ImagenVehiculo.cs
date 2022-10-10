using System.ComponentModel.DataAnnotations;

namespace TallerVehiculos.Entidades
{
    public class ImagenVehiculo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FotoVehiculo { get; set; }
    }
}
