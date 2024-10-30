﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record Raca
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string raca { get; set; } = default!;
    }
}
