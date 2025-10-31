namespace MiniCore_Comision.Models
{
    public class ResumenComisionViewModel
    {
        public string NombreVendedor { get; set; }
        public decimal TotalVentas { get; set; }

        public decimal PorcentajeComision => CalculadorComision.ObtenerPorcentaje(TotalVentas);

        public decimal TotalComision => CalculadorComision.CalcularComision(TotalVentas);
    }
}
