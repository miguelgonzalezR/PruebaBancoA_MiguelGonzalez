namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class TarjetaPagoViewModel
    {

        public Tarjetas Tarjeta { get; set; }
        public Pagos RPagos { get; set; }

        public TarjetaPagoViewModel()
        {
            Tarjeta = new Tarjetas();
            RPagos = new Pagos();
        }

    }
}
