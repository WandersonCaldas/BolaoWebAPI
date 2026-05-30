using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoWebAPI.Domain.Entities
{
    public class Participante
    {
        public long Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
