﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Funcionario : AppUser
    {
        public Funcionario()
        {
            Imoveis = new HashSet<Imovel>();
        }

        public int FuncionarioId { get; set; }
        public string FuncionarioNome { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
    }
}
