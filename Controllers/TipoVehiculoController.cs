using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data;
using TallerVehiculos.DTOs;
using TallerVehiculos.Entidades;

namespace TallerVehiculos.Controllers
{
    [ApiController]
    [Route("api/tipoVehiculos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class TipoVehiculoController : Controller
    {
        private readonly ILogger<TipoVehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoVehiculoController(ILogger<TipoVehiculoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoVehiculo>>> Get()
        {
            return await context.TipoVehiculos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoVehiculoDTO>> Get(int id)
        {
            TipoVehiculo tipoVehiculo = await context.TipoVehiculos.FirstOrDefaultAsync(context => context.Id == id);

            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return mapper.Map<TipoVehiculoDTO>(tipoVehiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoVehiculoCreacionDTO tipoVehiculoCreacionDTO)
        {
            TipoVehiculo tipoVehiculo = mapper.Map<TipoVehiculo>(tipoVehiculoCreacionDTO);
            context.Add(tipoVehiculo);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoVehiculo tipoVehiculo)
        {

            if (id != tipoVehiculo.Id)
            {
                return BadRequest("El tipo vehiculo no existe.");
            }

            bool existe = await context.TipoVehiculos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(tipoVehiculo);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            TipoVehiculo tipoVehiculo = await context.TipoVehiculos.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            context.Remove(tipoVehiculo);

            await context.SaveChangesAsync();

            return NoContent(); //204
        }
    }
}
