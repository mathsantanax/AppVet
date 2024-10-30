using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.ModelView
{
    public record PetAndTutor
    {
        public int Id { get; set; }
        public int IdPet { get; set; }
        public int IdServico { get; set; }
        public int IdRaca { get; set; }
        public int IdPetServico { get; set; }
        public string tutor { get; set; } = default!;
        public decimal tel { get; set; } = default!;
        public string nomePet { get; set; } = default!;
        public string IdMicrochip { get; set; } = default!;
        public string especie { get; set; } = default!;
        public int idade { get; set; } = default!;
        public string sexo { get; set; } = default!;
        public float peso { get; set; } = default!;
        public string raca { get; set; } = default!;
        public string Vacina { get; set; } = default!;
        public string Laboratorio { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime dataVacinacao { get; set; } = default!;
        public DateTime dataProximaVacinacao { get; set; } = default!;
    }
}
