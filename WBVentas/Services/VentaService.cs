using WBVentas.Models;
using WBVentas.Models.Request;

namespace WBVentas.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
           
                using (VentaRealProduccionContext db = new VentaRealProduccionContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {

                        try
                        {

                            var venta = new Ventum();
                            venta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                            venta.Fecha = DateTime.Now;
                            venta.IdCliente = model.IdCliente;
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var modelConcepto in model.Conceptos)
                            {
                                var concepto = new Models.Concepto();
                                concepto.Cantidad = modelConcepto.Cantidad;
                                concepto.IdProducto = modelConcepto.IdProducto;
                                concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                                concepto.Importe = modelConcepto.Importe;
                                concepto.IdVenta = venta.Id;
                                db.Conceptos.Add(concepto);
                                db.SaveChanges();
                            }
                            transaction.Commit();


                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error en la insersion");
                        }

                    }
                }

        }
    }
}
