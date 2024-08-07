namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class TarjetaRCompraHistorialViewModel
    {
        public Tarjetas Tarjeta { get; set; }
        public List<RCompra> RCompra { get; set; }

        public List<ComprasPorMes> ComprasPorMes { get; set; }

        public TarjetaRCompraHistorialViewModel()
        {
            Tarjeta = new Tarjetas();
            RCompra = new List<RCompra>();
            ComprasPorMes = new List<ComprasPorMes>();
        }

    }
}
