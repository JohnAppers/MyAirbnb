using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Avaliacao
    {
        public Avaliacao(int estrelas)
        {
            Estrelas = estrelas;
        }

        public int Id { get; set; }

        [Required]
        public int Estrelas { get; set; }

        public int? ClienteId { get; set; }

        public int ImovelId { get; set; }
    }
}
