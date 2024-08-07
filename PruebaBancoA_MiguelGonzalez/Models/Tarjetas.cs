using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class Tarjetas
    {
        public int Id { get; set; }
        public string Trajeta { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public decimal LimiteCredito { get; set; }

        public decimal SaldoActual { get; set; }

        public decimal SaldoDisponible { get; set; }

        public ICollection<RCompra>? Compras { get; set; }
    }
}
