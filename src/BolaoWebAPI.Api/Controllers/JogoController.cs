using AutoMapper;
using BolaoWebAPI.Api.Requests;
using BolaoWebAPI.Api.Responses;
using BolaoWebAPI.Domain.Entities;
using BolaoWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolaoWebAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JogoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public JogoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        return Ok(_mapper.Map<JogoResponse>(jogo));
    }

    [HttpGet("bolao/{bolaoId:long}")]
    public async Task<IActionResult> GetPorBolao(long bolaoId)
    {
        var jogos = await _context.Jogos
            .Where(x => x.BolaoId == bolaoId)
            .ToListAsync();

        return Ok(_mapper.Map<List<JogoResponse>>(jogos));
    }

    [HttpPost]
    public async Task<IActionResult> Post(JogoCreateRequest request)
    {
        var bolao = await _context.Boloes.FindAsync(request.BolaoId);

        if (bolao == null || !bolao.Ativo)
            return BadRequest("Bolão não encontrado ou inativo.");

        var jogo = _mapper.Map<Jogo>(request);

        _context.Jogos.Add(jogo);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<JogoResponse>(jogo));
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, JogoUpdateRequest request)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.Numeros = request.Numeros;

        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<JogoResponse>(jogo));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        _context.Jogos.Remove(jogo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}