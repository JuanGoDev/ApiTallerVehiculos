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
    [Route("api/tipoDocumentos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class TipoDocumentoController : Controller 
    {
        private readonly ILogger<TipoDocumentoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoDocumentoController(ILogger<TipoDocumentoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumento>>> Get()
        {
            return await context.TipoDocumentos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoDocumentoDTO>> Get(int id)
        {
            TipoDocumento tipoDocumento = await context.TipoDocumentos.FirstOrDefaultAsync(context => context.Id == id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return mapper.Map<TipoDocumentoDTO>(tipoDocumento);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoDocumentoCreacionDTO tipoDocumentoCreacionDTO)
        {
            TipoDocumento tipoDocumento = mapper.Map<TipoDocumento>(tipoDocumentoCreacionDTO);
            context.Add(tipoDocumento);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoDocumento tipoDocumento)
        {

            if (id != tipoDocumento.Id)
            {
                return BadRequest("El tipo de documento no existe.");
            }

            bool existe = await context.TipoDocumentos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(tipoDocumento);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            TipoDocumento tipoDocumento = await context.TipoDocumentos.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            context.Remove(tipoDocumento);

            await context.SaveChangesAsync();

            return NoContent(); //204
        }
    }
}
