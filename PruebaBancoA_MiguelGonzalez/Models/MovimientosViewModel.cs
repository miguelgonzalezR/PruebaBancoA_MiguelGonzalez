namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class MovimientosViewModel
    {
        public Tarjetas Tarjeta { get; set; }
        public List<Movimientos> Movi { get; set; }

        public MovimientosViewModel()
        {
            Tarjeta = new Tarjetas();
            Movi = new List<Movimientos>();
        }

    }
}
