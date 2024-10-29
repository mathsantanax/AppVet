using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record Pet
    {
        public string tutor { get; set; } = default!;
        public decimal tel { get; set; } = default!;
        public string IdMicrochip { get; set; } = default!;
        public string nomePet { get; set; } = default!;
        public string especie { get; set; } = default!;
        public string raca { get; set; } = default!;
        public int idade { get; set; } = default!;
        public string sexo { get; set; } = default!;
        public float peso { get; set; } = default!;
        public DateTime dataVacinacao { get; set; } = default!;
        public DateTime dataProximaVacinacao { get; set; } = default!;
        public string vacina { get; set; } = default!;
        public string laboratorio { get; set; } = default!;
        public decimal valor { get; set; } = default!;

    }
}
