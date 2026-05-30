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
    public class BolaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BolaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boloes = await _context.Boloes.Where(x => x.Ativo).ToListAsync();

            return Ok(_mapper.Map<List<BolaoResponse>>(boloes));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null)
                return NotFound();

            return Ok(_mapper.Map<BolaoResponse>(bolao));
        }

        [HttpPost]
        public async Task<IActionResult> Post(BolaoCreateRequest request)
        {
            var bolao = _mapper.Map<Bolao>(request);

            _context.Boloes.Add(bolao);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<BolaoResponse>(bolao);

            return CreatedAtAction(nameof(GetById),
                new { id = bolao.Id },
                response);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, BolaoUpdateRequest request)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null)
                return NotFound();

            _mapper.Map(request, bolao);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<BolaoResponse>(bolao);

            return Ok(response);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null)
                return NotFound();

            bolao.Ativo = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
