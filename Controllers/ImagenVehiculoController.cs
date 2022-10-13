using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data;
using TallerVehiculos.DTOs;
using TallerVehiculos.Entidades;
using TallerVehiculos.Servicios;

namespace TallerVehiculos.Controllers
{
    [ApiController]
    [Route("api/imagenVehiculos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class ImagenVehiculoController : Controller
    {
        private readonly ILogger<ImagenVehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";

        public ImagenVehiculoController(ILogger<ImagenVehiculoController> logger, ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<ImagenVehiculo>>> Get()
        {
            return await context.ImagenVehiculos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ImagenVehiculoDTO>> Get(int id)
        {
            ImagenVehiculo imagenVehiculo = await context.ImagenVehiculos.FirstOrDefaultAsync(context => context.Id == id);

            if (imagenVehiculo == null)
            {
                return NotFound();
            }

            return mapper.Map<ImagenVehiculoDTO>(imagenVehiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ImagenVehiculoCreacionDTO imagenVehiculoCreacionDTO)
        {
            ImagenVehiculo imagenVehiculo = mapper.Map<ImagenVehiculo>(imagenVehiculoCreacionDTO);

            if (imagenVehiculoCreacionDTO.FotoVehiculo != null)
            {
                imagenVehiculo.FotoVehiculo = await almacenadorArchivos.GuardarArchivo(contenedor, imagenVehiculoCreacionDTO.FotoVehiculo);
            }

            context.Add(imagenVehiculo);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ImagenVehiculo imagenVehiculo)
        {

            if (id != imagenVehiculo.Id)
            {
                return BadRequest("La imagen del vehículo no existe.");
            }

            bool existe = await context.ImagenVehiculos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(imagenVehiculo);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            ImagenVehiculo imagenVehiculo = await context.ImagenVehiculos.FirstOrDefaultAsync(x => x.Id == id);
            if (imagenVehiculo == null)
            {
                return NotFound();
            }

            context.Remove(imagenVehiculo);

            await context.SaveChangesAsync();

            return NoContent(); //204

        }
    }
}
