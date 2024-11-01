﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.DTO
{
    public record Service
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Vacina { get; set; } = default!;
        public string Laboratorio { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
