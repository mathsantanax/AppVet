using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record PetServico
    {

        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        Pet Pet { get; set; } = default!;
        Tutor Tutor { get; set; } = default!;
        public DateTime dataVacinacao { get; set; } = default!;
        public DateTime dataProximaVacinacao { get; set; } = default!;
        public Service Service { get; set; } = default!;
    }
}
