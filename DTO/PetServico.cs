using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    record PetServico
    {
        public string tutor { get; set; } = default!;
        public string nomePet { get; set; } = default!;
        public string especie { get; set; } = default!;
        public DateTime dataVacinacao { get; set; } = default!;
        public Service Service { get; set; } = default!;
    }
}
