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
        [ForeignKey(nameof(IdPet))]
        public int IdPet {  get; set; }

        [ForeignKey(nameof(IdServico))]
        public int IdServico { get; set; }
    }
}
