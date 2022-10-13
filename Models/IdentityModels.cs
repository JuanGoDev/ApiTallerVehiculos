using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.Models
{
    public class IdentityModels : IdentityUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [JsonIgnore]
        public TipoDocumento TipoDocumento { get; set; }
        [JsonIgnore]
        public ICollection<Vehiculo> Vehiculos { get; set; }
        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }
    }
}
