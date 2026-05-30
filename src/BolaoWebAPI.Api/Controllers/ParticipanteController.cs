using AutoMapper;
using BolaoWebAPI.Api.Requests;
using BolaoWebAPI.Api.Responses;
using BolaoWebAPI.Domain.Entities;
using BolaoWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolaoWebAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ParticipanteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var participantes = await _context.Participantes.Where(x => x.Ativo).ToListAsync();

            return Ok(_mapper.Map<List<ParticipanteResponse>>(participantes));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null || !participante.Ativo)
                return NotFound();

            return Ok(_mapper.Map<ParticipanteResponse>(participante));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParticipanteCreateRequest request)
        {
            var participante = _mapper.Map<Participante>(request);

            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<ParticipanteResponse>(participante);

            return CreatedAtAction(nameof(GetById), new { id = participante.Id }, response);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, ParticipanteUpdateRequest request)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null || !participante.Ativo)
                return NotFound();

            _mapper.Map(request, participante);

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ParticipanteResponse>(participante));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null || !participante.Ativo)
                return NotFound();

            participante.Ativo = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
