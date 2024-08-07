namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class RCompra
    {
        public int Id { get; set; }

        public int TarjetaId { get; set; }
        public DateTime FechaCompra { get; set; }
        
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }


        //public Tarjetas? Tarjeta { get; set; }
    }
}
