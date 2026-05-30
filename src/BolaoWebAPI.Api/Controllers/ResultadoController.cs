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
public class ResultadoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ResultadoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("bolao/{bolaoId:long}")]
    public async Task<IActionResult> GetPorBolao(long bolaoId)
    {
        var resultados = await _context.Resultados
            .Where(x => x.BolaoId == bolaoId)
            .ToListAsync();

        return Ok(_mapper.Map<List<ResultadoResponse>>(resultados));
    }

    [HttpPost]
    public async Task<IActionResult> Post(ResultadoCreateRequest request)
    {
        var bolao = await _context.Boloes.FindAsync(request.BolaoId);

        if (bolao == null || !bolao.Ativo)
            return BadRequest("Bolão não encontrado ou inativo.");

        var resultado = _mapper.Map<Resultado>(request);

        _context.Resultados.Add(resultado);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<ResultadoResponse>(resultado));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _context.Resultados.FindAsync(id);

        if (resultado == null)
            return NotFound();

        _context.Resultados.Remove(resultado);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("bolao/{bolaoId:long}/conferencia")]
    public async Task<IActionResult> ConferirJogos(long bolaoId)
    {
        var resultado = await _context.Resultados
            .Where(x => x.BolaoId == bolaoId)
            .OrderByDescending(x => x.DataResultado)
            .FirstOrDefaultAsync();

        if (resultado == null)
            return NotFound("Resultado não encontrado para este bolão.");

        var jogos = await _context.Jogos
            .Where(x => x.BolaoId == bolaoId)
            .ToListAsync();

        var numerosSorteados = resultado.NumerosSorteados
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList();

        var response = jogos.Select(jogo =>
        {
            var numerosJogo = jogo.Numeros
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            var numerosAcertados = numerosJogo
                .Where(numero => numerosSorteados.Contains(numero))
                .ToList();

            return new ConferenciaJogoResponse
            {
                JogoId = jogo.Id,
                NumerosJogo = jogo.Numeros,
                NumerosSorteados = resultado.NumerosSorteados,
                NumerosAcertados = numerosAcertados,
                QuantidadeAcertos = numerosAcertados.Count
            };
        })
        .OrderByDescending(x => x.QuantidadeAcertos)
        .ToList();

        return Ok(response);
    }
}