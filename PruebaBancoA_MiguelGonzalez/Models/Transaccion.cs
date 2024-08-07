namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string NumeroAutorizacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
