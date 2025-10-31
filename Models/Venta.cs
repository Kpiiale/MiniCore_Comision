using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCore_Comision.Models
{
    public class Venta
    {
        public int Id { get; set; }

        [Required]
        public int VendedorId { get; set; }

        [ForeignKey("VendedorId")]
        public Vendedor Vendedor { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
