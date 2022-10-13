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
    [Route("api/detalleHistoriales")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class DetalleHistorialController : Controller
    {
        private readonly ILogger<DetalleHistorialController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DetalleHistorialController(ILogger<DetalleHistorialController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleHistorial>>> Get()
        {
            return await context.DetalleHistoriales.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetalleHistorialDTO>> Get(int id)
        {
            DetalleHistorial detalleHistorial = await context.DetalleHistoriales.FirstOrDefaultAsync(context => context.Id == id);

            if (detalleHistorial == null)
            {
                return NotFound();
            }

            return mapper.Map<DetalleHistorialDTO>(detalleHistorial);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleHistorialCreacionDTO detalleHistorialCreacionDTO)
        {
            DetalleHistorial detalleHistorial = mapper.Map<DetalleHistorial>(detalleHistorialCreacionDTO);
            context.Add(detalleHistorial);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, DetalleHistorial detalleHistorial)
        {

            if (id != detalleHistorial.Id)
            {
                return BadRequest("El vuelo no existe.");
            }

            bool existe = await context.DetalleHistoriales.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(detalleHistorial);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            DetalleHistorial vuelo = await context.DetalleHistoriales.FirstOrDefaultAsync(x => x.Id == id);
            if (vuelo == null)
            {
                return NotFound();
            }

            context.Remove(vuelo);

            await context.SaveChangesAsync();

            return NoContent(); //204

        }
    }
}
