using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaCasino.Entidades;
using PiaCasino.DTOs;
using Microsoft.Extensions.Logging;

namespace PiaCasino.Controllers
{

    [ApiController]
    [Route("Participante")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class ParticipanteController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ParticipanteController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet("Participantes")]//Mostrar todos los participantes
        [AllowAnonymous]

        public async Task<ActionResult<List<GetParticipantesDTO>>> Get()
        {
            var participantes = await dbContext.Participantes.ToListAsync();
            return mapper.Map<List<GetParticipantesDTO>>(participantes);
        }

        [HttpPost] //Crear un Participante
        public async Task<ActionResult> Post(CreacionParticipanteDTO creacionParticipante)
        {


            var vato = mapper.Map<Participante>(creacionParticipante);
            dbContext.Add(vato);
            await dbContext.SaveChangesAsync();

            var participanteDTO = mapper.Map<GetParticipantesDTO>(vato);

            return CreatedAtRoute("ObtenerParticipante", new { id = vato.Id }, participanteDTO);


        }

        [HttpPost("CrearRifa")]   //Crear una Rifa
        public async Task<ActionResult> Post(CreacionRifaDTO creacionRifa)
        {
            var existeRifa = await dbContext.Rifas.AnyAsync(x => x.NombreRifa == creacionRifa.NombreRifa);

            if (existeRifa)
            {
                return BadRequest($"Ya existe esta rifa con el nombre {creacionRifa.NombreRifa}");
            }

            var Rifita = mapper.Map<Rifa>(creacionRifa);
            dbContext.Add(Rifita);
            await dbContext.SaveChangesAsync();

            var RifitaDTO = mapper.Map<GetRifaDTO>(Rifita);

            return CreatedAtRoute("ObtenerRifa", new { id = Rifita.Id }, RifitaDTO);
        }

       


        [HttpDelete("{id:int}")] // Eliminar un Participante de la Rifa
        public async Task<ActionResult> DeleteById(int id)
        {
            var existe = await dbContext.ParticipanteRifa.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            dbContext.Remove(new ParticipanteRifa()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
        
            return Ok();
        }

    }
}
