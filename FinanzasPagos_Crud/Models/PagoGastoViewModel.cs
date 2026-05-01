namespace FinanzasPagos_Crud.Models
{
    public class PagoGastoViewModel
    {
        public IEnumerable<Pago> Pagos { get; set; } = new List<Pago>();
        public IEnumerable<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}