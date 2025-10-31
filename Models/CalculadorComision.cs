namespace MiniCore_Comision.Models
{
    public class CalculadorComision
    {
        public static decimal ObtenerPorcentaje(decimal totalVentas)
        {
            if (totalVentas < 20)
                return 0.05m;
            else if (totalVentas < 50)
                return 0.10m;
            else
                return 0.12m;
        }

        public static decimal CalcularComision(decimal totalVentas)
        {
            var porcentaje = ObtenerPorcentaje(totalVentas);
            return totalVentas * porcentaje;
        }
    }
}
