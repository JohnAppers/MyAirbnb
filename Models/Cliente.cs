using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Cliente : AppUser
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int ClienteId { get; set; }

        public string NomeCliente { get; set; }

        public int Contacto { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
