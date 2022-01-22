using System.Collections.Generic;

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
