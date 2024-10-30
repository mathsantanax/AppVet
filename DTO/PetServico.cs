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
        public DateTime dataVacinacao { get; set; } = default!;
        public DateTime dataProximaVacinacao { get; set; } = default!;
        [ForeignKey(nameof(IdTutor))]
        public int IdTutor { get; set; }
        [ForeignKey(nameof(IdService))]
        public int IdPet { get; set; }
        [ForeignKey(nameof(IdService))]
        public int IdService { get; set; }
    }
}
