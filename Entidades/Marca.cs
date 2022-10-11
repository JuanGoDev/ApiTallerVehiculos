using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TallerVehiculos.Entidades
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Procedencia { get; set; }
        [JsonIgnore]
        public ICollection<Vehiculo> Vehiculos { get; set; }

    }
}
