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

        [HttpGet("{id:long}/resumo")]
        public async Task<IActionResult> GetResumo(long id)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null || !bolao.Ativo)
                return NotFound();

            var participantes = await _context.BolaoParticipantes
                .Where(x => x.BolaoId == id)
                .ToListAsync();

            var cotasVendidas = participantes.Sum(x => x.QuantidadeCotas);
            var valorPago = participantes
                .Where(x => x.Pago)
                .Sum(x => x.ValorTotal);

            var valorTotalPrevisto = participantes.Sum(x => x.ValorTotal);

            var response = new BolaoResumoResponse
            {
                BolaoId = bolao.Id,
                TotalCotas = bolao.QuantidadeCotas,
                CotasVendidas = cotasVendidas,
                CotasDisponiveis = bolao.QuantidadeCotas - cotasVendidas,
                ValorTotalPrevisto = valorTotalPrevisto,
                ValorPago = valorPago,
                ValorPendente = valorTotalPrevisto - valorPago,
                QuantidadeParticipantes = participantes.Count
            };

            return Ok(response);
        }

        [HttpGet("{id:long}/dashboard")]
        public async Task<IActionResult> GetDashboard(long id)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null || !bolao.Ativo)
                return NotFound();

            var participantes = await _context.BolaoParticipantes
                .Where(x => x.BolaoId == id)
                .ToListAsync();

            var quantidadeJogos = await _context.Jogos
                .CountAsync(x => x.BolaoId == id);

            var cotasVendidas = participantes.Sum(x => x.QuantidadeCotas);
            var valorRecebido = participantes
                .Where(x => x.Pago)
                .Sum(x => x.ValorTotal);

            var valorArrecadado = participantes.Sum(x => x.ValorTotal);

            var response = new BolaoDashboardResponse
            {
                BolaoId = bolao.Id,
                NomeBolao = bolao.Nome,
                QuantidadeParticipantes = participantes.Count,
                QuantidadeJogos = quantidadeJogos,
                CotasVendidas = cotasVendidas,
                CotasDisponiveis = bolao.QuantidadeCotas - cotasVendidas,
                ValorArrecadado = valorArrecadado,
                ValorRecebido = valorRecebido,
                ValorPendente = valorArrecadado - valorRecebido
            };

            return Ok(response);
        }

        [HttpGet("{id:long}/rateio")]
        public async Task<IActionResult> GetRateio(long id, [FromQuery] decimal valorPremio)
        {
            var bolao = await _context.Boloes.FindAsync(id);

            if (bolao == null || !bolao.Ativo)
                return NotFound();

            var participantesBolao = await _context.BolaoParticipantes
                .Where(x => x.BolaoId == id && x.Pago)
                .ToListAsync();

            if (!participantesBolao.Any())
                return BadRequest("Não existem participantes pagos para calcular o rateio.");

            var totalCotasPagas = participantesBolao.Sum(x => x.QuantidadeCotas);

            var participantesIds = participantesBolao
                .Select(x => x.ParticipanteId)
                .ToList();

            var participantes = await _context.Participantes
                .Where(x => participantesIds.Contains(x.Id))
                .ToListAsync();

            var rateioParticipantes = participantesBolao.Select(item =>
            {
                var participante = participantes.First(x => x.Id == item.ParticipanteId);

                var percentual = (decimal)item.QuantidadeCotas / totalCotasPagas * 100;
                var valorParticipante = valorPremio * percentual / 100;

                return new RateioParticipanteResponse
                {
                    ParticipanteId = participante.Id,
                    NomeParticipante = participante.Nome,
                    QuantidadeCotas = item.QuantidadeCotas,
                    PercentualParticipacao = Math.Round(percentual, 2),
                    ValorPremio = Math.Round(valorParticipante, 2)
                };
            })
            .OrderByDescending(x => x.ValorPremio)
            .ToList();

            var response = new RateioResponse
            {
                BolaoId = bolao.Id,
                NomeBolao = bolao.Nome,
                ValorPremioTotal = valorPremio,
                TotalCotas = totalCotasPagas,
                Participantes = rateioParticipantes
            };

            return Ok(response);
        }
    }
}
