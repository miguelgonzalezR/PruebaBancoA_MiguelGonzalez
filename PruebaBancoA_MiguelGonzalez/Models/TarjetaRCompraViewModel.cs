namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class TarjetaRCompraViewModel
    {
        public Tarjetas Tarjeta { get; set; }
        public RCompra RCompra { get; set; }

        public TarjetaRCompraViewModel()
        {
            Tarjeta = new Tarjetas();
            RCompra = new RCompra();
        }

    }
}
