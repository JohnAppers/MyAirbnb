using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Imovel
    {
        public Imovel()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
