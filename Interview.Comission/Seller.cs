namespace Interview.Comission
{
    public class Seller(double grossSales)
    {
        public double VendasBrutas { get; } = grossSales;

        public double CalculateSalary()
        {
            return 200 + (0.09 * VendasBrutas);
        }
    }
}
