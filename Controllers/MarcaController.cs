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
    [Route("api/marcas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class MarcaController : Controller
    {
        private readonly ILogger<MarcaController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MarcaController(ILogger<MarcaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get()
        {
            return await context.Marcas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MarcaDTO>> Get(int id)
        {
            Marca marca = await context.Marcas.FirstOrDefaultAsync(context => context.Id == id);

            if (marca == null)
            {
                return NotFound();
            }

            return mapper.Map<MarcaDTO>(marca);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MarcaCreacionDTO marcaCreacionDto)
        {
            Marca marca = mapper.Map<Marca>(marcaCreacionDto);
            context.Add(marca);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Marca marca)
        {

            if (id != marca.Id)
            {
                return BadRequest("La marca no existe.");
            }

            bool existe = await context.Marcas.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(marca);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Marca marca = await context.Marcas.FirstOrDefaultAsync(x => x.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            context.Remove(marca);

            await context.SaveChangesAsync();

            return NoContent(); //204

        }
    }
}
