namespace WBVentas.Models.Request
{
    public class ProductoRequest
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public int PrecioUnitario { get; set; }
        public int Costo { get; set; }
    }
}
