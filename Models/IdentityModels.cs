using TallerVehiculos.Entidades;

namespace TallerVehiculos.Models
{
    public class IdentityModels
    {
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}
