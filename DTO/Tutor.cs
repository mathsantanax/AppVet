using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record Tutor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string tutor { get; set; } = default!;
        public decimal tel { get; set; } = default!;
        public Pet Pet { get; set; } = default!;
        public PetServico PetServico { get; set; } = default!;
    }
}
