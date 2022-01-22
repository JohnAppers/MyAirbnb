using System.Collections.Generic;

namespace MyAirbnb.Models
{
    public class Funcionario : AppUser
    {
        public Funcionario()
        {
            Imoveis = new HashSet<Imovel>();
            Reservas = new HashSet<Reserva>();
        }

        public int FuncionarioId { get; set; }
        public string FuncionarioNome { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<Imovel> Imoveis { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
