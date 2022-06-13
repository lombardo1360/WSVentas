using WBVentas.Models.Request;

namespace WBVentas.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);
    }
}