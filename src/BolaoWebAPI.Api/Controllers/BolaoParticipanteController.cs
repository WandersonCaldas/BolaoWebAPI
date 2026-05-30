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
public class BolaoParticipanteController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BolaoParticipanteController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("bolao/{bolaoId:long}")]
    public async Task<IActionResult> GetPorBolao(long bolaoId)
    {
        var participantes = await _context.BolaoParticipantes
            .Where(x => x.BolaoId == bolaoId)
            .ToListAsync();

        return Ok(_mapper.Map<List<BolaoParticipanteResponse>>(participantes));
    }

    [HttpPost]
    public async Task<IActionResult> Post(BolaoParticipanteCreateRequest request)
    {
        var bolao = await _context.Boloes.FindAsync(request.BolaoId);

        if (bolao == null || !bolao.Ativo)
            return BadRequest("Bolão não encontrado ou inativo.");

        var participante = await _context.Participantes.FindAsync(request.ParticipanteId);

        if (participante == null || !participante.Ativo)
            return BadRequest("Participante não encontrado ou inativo.");

        var jaExiste = await _context.BolaoParticipantes
            .AnyAsync(x => x.BolaoId == request.BolaoId &&
                           x.ParticipanteId == request.ParticipanteId);

        if (jaExiste)
            return BadRequest("Este participante já está vinculado a este bolão.");

        var bolaoParticipante = new BolaoParticipante
        {
            BolaoId = request.BolaoId,
            ParticipanteId = request.ParticipanteId,
            QuantidadeCotas = request.QuantidadeCotas,
            ValorCota = bolao.ValorCota,
            ValorTotal = request.QuantidadeCotas * bolao.ValorCota,
            Pago = false
        };

        _context.BolaoParticipantes.Add(bolaoParticipante);

        await _context.SaveChangesAsync();

        var response = _mapper.Map<BolaoParticipanteResponse>(bolaoParticipante);

        return Ok(response);
    }

    [HttpPut("{id:long}/pagamento")]
    public async Task<IActionResult> AtualizarPagamento(long id, BolaoParticipantePagamentoRequest request)
    {
        var bolaoParticipante = await _context.BolaoParticipantes.FindAsync(id);

        if (bolaoParticipante == null)
            return NotFound();

        bolaoParticipante.Pago = request.Pago;

        await _context.SaveChangesAsync();

        var response = _mapper.Map<BolaoParticipanteResponse>(bolaoParticipante);

        return Ok(response);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var bolaoParticipante = await _context.BolaoParticipantes.FindAsync(id);

        if (bolaoParticipante == null)
            return NotFound();

        _context.BolaoParticipantes.Remove(bolaoParticipante);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, BolaoParticipanteUpdateRequest request)
    {
        var bolaoParticipante = await _context.BolaoParticipantes.FindAsync(id);

        if (bolaoParticipante == null)
            return NotFound();

        bolaoParticipante.QuantidadeCotas = request.QuantidadeCotas;
        bolaoParticipante.ValorTotal = request.QuantidadeCotas * bolaoParticipante.ValorCota;

        await _context.SaveChangesAsync();

        var response = _mapper.Map<BolaoParticipanteResponse>(bolaoParticipante);

        return Ok(response);
    }
}