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
    [Route("api/historiales")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class HistorialController : Controller
    {
        private readonly ILogger<HistorialController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HistorialController(ILogger<HistorialController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Historial>>> Get()
        {
            return await context.Historiales.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistorialDTO>> Get(int id)
        {
            Historial historial = await context.Historiales.FirstOrDefaultAsync(context => context.Id == id);

            if (historial == null)
            {
                return NotFound();
            }

            return mapper.Map<HistorialDTO>(historial);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HistorialCreacionDTO vueloCreacionDto)
        {
            Historial historial = mapper.Map<Historial>(vueloCreacionDto);
            context.Add(historial);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Historial historial)
        {

            if (id != historial.Id)
            {
                return BadRequest("El historial no existe.");
            }

            bool existe = await context.Historiales.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(historial);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Historial historial = await context.Historiales.FirstOrDefaultAsync(x => x.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            context.Remove(historial);

            await context.SaveChangesAsync();

            return NoContent(); //204

        }
    }
}
