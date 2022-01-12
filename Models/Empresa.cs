using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyAirbnb.Models
{
    public class Empresa
    {
        public Empresa()
        {
            Imoveis = new HashSet<Imovel>();
        }

        public int EmpresaId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Telemóvel / Telefone")]
        public int Contacto { get; set; }

        public ICollection<Imovel> Imoveis { get; set; }
    }
}
