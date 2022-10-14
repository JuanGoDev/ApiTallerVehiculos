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
    [Route("api/procedimientos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class ProcedimientoController : Controller
    {
        private readonly ILogger<ProcedimientoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProcedimientoController(ILogger<ProcedimientoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Procedimiento>>> Get()
        {
            return await context.Procedimientos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProcedimientoDTO>> Get(int id)
        {
            Procedimiento procedimiento = await context.Procedimientos.FirstOrDefaultAsync(context => context.Id == id);

            if (procedimiento == null)
            {
                return NotFound();
            }

            return mapper.Map<ProcedimientoDTO>(procedimiento);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProcedimientoCreacionDTO vueloCreacionDto)
        {
            Procedimiento procedimiento = mapper.Map<Procedimiento>(vueloCreacionDto);
            context.Add(procedimiento);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Procedimiento procedimiento)
        {

            if (id != procedimiento.Id)
            {
                return BadRequest("El procedimiento no existe");
            }

            bool existe = await context.Procedimientos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(procedimiento);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Procedimiento procedimiento = await context.Procedimientos.FirstOrDefaultAsync(x => x.Id == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            context.Remove(procedimiento);

            await context.SaveChangesAsync();

            return NoContent(); //204
        }
    }
}
