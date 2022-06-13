using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBVentas.Models;
using WBVentas.Models.Request;
using WBVentas.Models.Response;
using WBVentas.Services;

namespace WBVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {

        private IVentaService _venta;

        public VentaController (IVentaService venta)
        {
            _venta = venta;
        }

        [HttpPost]
        public IActionResult add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {

                _venta.Add(model);
                respuesta.Exito = 1;

            }
            catch(Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}