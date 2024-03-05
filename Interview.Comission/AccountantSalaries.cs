namespace Interview.Comission
{
    public class AccountantSalaries
    {
        private List<int> Accountants;

        public AccountantSalaries()
        {
            Accountants = new List<int>(10);

            for (int i = 0; i < 10; i++)
            {
                Accountants.Add(0);
            }
        }

        public void CountSalary(Seller[] selles)
        {
            foreach (var seller in selles)
            {
                var salary = seller.CalculateSalary();
                var index = (int)(salary / 100) - 2;

                if (index < 0)
                {
                    index = 0;
                }
                else if (index >= Accountants.Count)
                {
                    index = Accountants.Count - 1;
                }

                Accountants[index]++;
            }
        }

        public void PrintResults()
        {
            char interval = 'a';
            foreach (var counter in Accountants)
            {
                Console.WriteLine($"Intervalo {interval++}: {counter} vendedores");
            }
        }
    }
}
