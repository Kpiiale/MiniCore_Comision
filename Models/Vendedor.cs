using System.ComponentModel.DataAnnotations;

namespace MiniCore_Comision.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
