namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class Movimientos
    {
        public int Id { get; set; }

        public int TarjetaId { get; set; }
        public DateTime FechaCompra { get; set; }

        public decimal Monto { get; set; }
        public string? Descripcion { get; set; }

        public string Tipo { get; set; }
    }
}
