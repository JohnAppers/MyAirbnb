using System;
using System.ComponentModel.DataAnnotations;

namespace MyAirbnb.Models
{
    public class Reserva
    {
        public Reserva()
        {
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Data de chegada")]
        public DateTime DateStart { get; set; }
        [Required]
        [Display(Name = "Data de saída")]
        public DateTime DateEnd { get; set; }


        [Required]
        [Display(Name = "Imóvel")]
        public int? ImovelId { get; set; }
        public Imovel Imovel { get; set; }
        [Display(Name = "Avaliação do imóvel")]
        [Range(1, 5)]
        public int? RatingImovel { get; set; }
        [Display(Name = "Comentários")]
        public string CommentImovel { get; set; }


        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        [Display(Name = "Avaliação do funcionário")]
        [Range(1, 5)]
        public int? RatingFuncionario { get; set; }
        [Display(Name = "Comentários")]
        public string CommentFuncionario { get; set; }


        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [Display(Name = "Avaliação do proprietário")]
        [Range(1, 5)]
        public int? RatingGestor { get; set; }
        [Display(Name = "Comentários")]
        public string CommentGestor { get; set; }


        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Avaliação do cliente")]
        [Range(1, 5)]
        public int? RatingCliente { get; set; }
        [Display(Name = "Comentários")]
        public string CommentCliente { get; set; }

    }
}
