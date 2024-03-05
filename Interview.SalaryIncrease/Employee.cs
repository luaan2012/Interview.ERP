namespace Interview.SalaryIncrease
{
    public class Employee()
    {
        public double PreviousSalary { get; private set; }
        public double PercentIncrease { get; private set; }
        public double ValueIncrease { get; private set; }
        public double NewSalary { get; private set; }

        public void ReadSalaryIn()
        {
            Console.WriteLine("Digite o salário do colaborador: ");
            PreviousSalary = double.Parse(Console.ReadLine());
        }

        public void CalculateSalary()
        {
            PercentIncrease = PreviousSalary switch
            {
                _ when PreviousSalary <= 280 => 0.20,
                _ when PreviousSalary > 280 && PreviousSalary <= 700 => 0.15,
                _ when PreviousSalary > 700 && PreviousSalary <= 1500 => 0.10,
                _ => 0.05
            };

            ValueIncrease = PreviousSalary * PercentIncrease;
            NewSalary = PreviousSalary + ValueIncrease;
        }

        public void PrinfInformations()
        {

            Console.WriteLine($"Salário antes do reajuste: {PreviousSalary:C}");
            Console.WriteLine($"Percentual de aumento aplicado: {PercentIncrease:P2}");
            Console.WriteLine($"Valor do aumento: {ValueIncrease:C}");
            Console.WriteLine($"Novo salário após o aumento: {NewSalary:C}");
        }
    }
}
