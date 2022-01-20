using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Reserva
    {
        public Reserva()
        {
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Data de reserva")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Imóvel")]
        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public int ratingImovel { get; set; }
        public string commentImovel { get; set; }
        public int ratingFuncionario { get; set; }
        public string commentFuncionario { get; set; }
        public int ratingGestor { get; set; }
        public string commentGestor { get; set; }
        public int ratingCliente { get; set; }
        public string commentCliente { get; set; }

    }
}
