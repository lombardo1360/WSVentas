using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBVentas.Models;
using WBVentas.Models.Request;
using WBVentas.Models.Response;

namespace WBVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealProduccionContext db = new VentaRealProduccionContext())
                {
                    var oProducto = new Producto();
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.PrecioUnitario = oModel.PrecioUnitario;
                    oProducto.Costo = oModel.Costo;
                    db.Productos.Add(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealProduccionContext db = new VentaRealProduccionContext())
                {
                    var lst = db.Productos.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealProduccionContext db = new VentaRealProduccionContext())
                {
                    var oCliente = db.Productos.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.PrecioUnitario = oModel.PrecioUnitario;
                    oCliente.Costo = oModel.Costo;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealProduccionContext db = new VentaRealProduccionContext())
                {
                    var oProducto = db.Productos.Find(Id);
                    db.Remove(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

    }
}
