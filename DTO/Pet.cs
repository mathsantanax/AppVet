using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record Pet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nomePet { get; set; } = default!;
        public string IdMicrochip { get; set; } = default!;
        public string especie { get; set; } = default!;
        public int idade { get; set; } = default!;
        public string sexo { get; set; } = default!;
        public float peso { get; set; } = default!;
        public Raca raca { get; set; } = default!;
    }
}
