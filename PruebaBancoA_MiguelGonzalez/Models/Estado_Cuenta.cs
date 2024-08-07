using System.Transactions;

namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class Estado_Cuenta
    {
        public string NombreCliente { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal Limite { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal SaldoDisponible { get; set; }
        public List<Transaccion> Transacciones { get; set; }
    }
}
