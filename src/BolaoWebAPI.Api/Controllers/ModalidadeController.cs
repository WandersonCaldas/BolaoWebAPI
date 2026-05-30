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
public class ModalidadeController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ModalidadeController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var modalidades = await _context.Modalidades
            .Where(x => x.Ativo)
            .ToListAsync();

        return Ok(_mapper.Map<List<ModalidadeResponse>>(modalidades));
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var modalidade = await _context.Modalidades.FindAsync(id);

        if (modalidade == null || !modalidade.Ativo)
            return NotFound();

        return Ok(_mapper.Map<ModalidadeResponse>(modalidade));
    }

    [HttpPost]
    public async Task<IActionResult> Post(ModalidadeCreateRequest request)
    {
        var modalidade = _mapper.Map<Modalidade>(request);

        _context.Modalidades.Add(modalidade);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<ModalidadeResponse>(modalidade);

        return CreatedAtAction(nameof(GetById), new { id = modalidade.Id }, response);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, ModalidadeUpdateRequest request)
    {
        var modalidade = await _context.Modalidades.FindAsync(id);

        if (modalidade == null || !modalidade.Ativo)
            return NotFound();

        _mapper.Map(request, modalidade);

        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<ModalidadeResponse>(modalidade));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var modalidade = await _context.Modalidades.FindAsync(id);

        if (modalidade == null || !modalidade.Ativo)
            return NotFound();

        modalidade.Ativo = false;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}