using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Models;

namespace TallerVehiculos.Entidades
{
    public class Vehiculo
    {
        [Key]
        public int Placa { get; set; }
        [Required]
        public string IdUsuario { get; set; }
        [Required]
        public int IdMarca { get; set; }
        [Required]
        public int IdTipoVehiculo { get; set; }
        [Required]
        public int Kilometros { get; set; }
        [Required]
        [StringLength(50)]
        public string AgenciaTransito { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [JsonIgnore]
        public IdentityModels IdentityModels { get; set; }
        [JsonIgnore]
        public Marca Marca { get; set; }
        [JsonIgnore]
        public TipoVehiculo TipoVehiculo { get; set; }
        [JsonIgnore]
        public ICollection<ImagenVehiculo> ImagenVehiculos { get; set; }
        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }
    }
}
