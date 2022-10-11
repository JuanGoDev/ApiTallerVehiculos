using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.Models
{
    public class IdentityModels : IdentityUser
    {        
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdTipoDocumento { get; set; }
        [JsonIgnore]
        public TipoDocumento TipoDocumento { get; set; }
        [JsonIgnore]
        public ICollection<Vehiculo> Vehiculos { get; set; }
        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }
    }
}
