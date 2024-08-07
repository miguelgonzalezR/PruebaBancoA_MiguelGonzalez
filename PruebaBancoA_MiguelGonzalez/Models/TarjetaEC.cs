namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class TarjetaEC
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Trajeta { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinimaAPagar { get; set; }
        public decimal MontoTotalAPagar { get; set; }
        public decimal PagoContadoConIntereses { get; set; }

        public List<RCompra> ComprasMesActual { get; set; }
        public decimal TotalComprasMesActual { get; set; }
        public decimal TotalComprasMesAnterior { get; set; }

    }
}
