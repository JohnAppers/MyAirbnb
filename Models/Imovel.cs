using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAirbnb.Models
{
    public class Imovel
    {
        public Imovel()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }

        [Display(Name = "Foto")]
        public string ImagemNome { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Reserva> Reservas { get; set; }

        [Required]
        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
