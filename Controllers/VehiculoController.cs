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
    [Route("api/vehiculos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VehiculoController(ILogger<VehiculoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
            return await context.Vehiculos.ToListAsync();
        }

        [HttpGet("{placa:int}")]
        public async Task<ActionResult<VehiculoDTO>> Get(int placa)
        {
            Vehiculo vehiculo = await context.Vehiculos.FirstOrDefaultAsync(context => context.Placa == placa);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return mapper.Map<VehiculoDTO>(vehiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VehiculoCreacionDTO vehiculoCreacionDTO)
        {
            Vehiculo vehiculo = mapper.Map<Vehiculo>(vehiculoCreacionDTO);
            context.Add(vehiculo);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{placa}")]
        public async Task<ActionResult> Put(int placa, Vehiculo vehiculo)
        {

            if (placa != vehiculo.Placa)
            {
                return BadRequest("La placa del vehiculo no existe.");
            }

            bool existe = await context.Vehiculos.AnyAsync(x => x.Placa == placa);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(vehiculo);
            await context.SaveChangesAsync();
            return Ok();//200
        }

        [HttpDelete("{placa}")]
        public async Task<ActionResult> Delete(int placa)
        {
            Vehiculo vehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.Placa == placa);
            if (vehiculo == null)
            {
                return NotFound();
            }

            context.Remove(vehiculo);

            await context.SaveChangesAsync();

            return NoContent(); //204
        }
    }
}
