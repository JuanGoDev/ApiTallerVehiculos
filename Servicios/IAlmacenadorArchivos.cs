using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerVehiculos.Servicios
{
    public interface IAlmacenadorArchivos
    {
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contentType);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> GuardarArchivo(string contenedor, IFormFile foto);
    }
}
