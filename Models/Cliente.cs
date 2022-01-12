using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Avaliacoes = new HashSet<Avaliacao>();
        }

        public int ClienteId { get; set; }

        public int UserId { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
