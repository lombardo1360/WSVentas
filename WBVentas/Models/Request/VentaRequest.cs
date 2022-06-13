using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WBVentas.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage ="El valor de idCliente debe ser mayor a 0")]
        [ExisteCliente(ErrorMessage ="El cliente no existe")]
        public int IdCliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Deben existir conceptos")]
        public List<Concepto> Conceptos { get; set; }

        public VentaRequest()
        {

            this.Conceptos = new List<Concepto>();
        }
    }

    public class Concepto
    {
        public  int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int IdProducto { get; set; }
    }

    #region Validation

    public class ExisteCliente: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int IdCliente = (int)value;

            using (var db = new Models.VentaRealProduccionContext())
            {
                if (db.Clientes.Find(IdCliente) == null) return false;
            }

            return true;
        }
    }
    
    #endregion
}