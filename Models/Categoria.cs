using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Imoveis = new HashSet<Imovel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
    }
}
