using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoWebAPI.Domain.Entities
{
    public class Bolao
    {
        public long Id { get; set; }

        public long ModalidadeId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public decimal ValorCota { get; set; }

        public int QuantidadeCotas { get; set; }

        public DateTime DataSorteio { get; set; }

        public bool Ativo { get; set; } = true;        
    }
}
