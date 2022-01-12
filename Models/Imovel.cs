using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyAirbnb.Models
{
    public class Imovel
    {
        public Imovel()
        {
            Avaliacoes = new HashSet<Avaliacao>();
        }

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; }

        public int? CategoriaId { get; set; }
        [Required]
        public Categoria Categoria { get; set; }

        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
