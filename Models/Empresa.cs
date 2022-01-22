using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAirbnb.Models
{
    public class Empresa : AppUser
    {
        public Empresa()
        {
            Imoveis = new HashSet<Imovel>();
            Funcionarios = new HashSet<Funcionario>();
            Reservas = new HashSet<Reserva>();
        }

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Telemóvel / Telefone")]
        public int Contacto { get; set; }

        public ICollection<Imovel> Imoveis { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
