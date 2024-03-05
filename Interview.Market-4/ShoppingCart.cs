namespace Interview.Market_4
{
    public class ShoppingCart
    {
        private string MeatType;
        private double PricePerKg;
        private double Quantity;
        private double TotalPrice;
        private bool IsTabajaraCardPayment;

        public ShoppingCart(int meatType, double quantity)
        {
            switch (meatType)
            {
                case 1:
                    MeatType = "File Duplo";
                    PricePerKg = (quantity <= 5) ? 4.90 : 5.80;
                    break;
                case 2:
                    MeatType = "Alcatra";
                    PricePerKg = (quantity <= 5) ? 5.90 : 6.80;
                    break;
                case 3:
                    MeatType = "Picanha";
                    PricePerKg = (quantity <= 5) ? 6.90 : 7.80;
                    break;
                default:
                    Console.WriteLine("Tipo de carne inválida.");
                    break;
            }

            Quantity = quantity;
        }

        public void GenerateReceipt()
        {
            TotalPrice = Quantity * PricePerKg;
            Console.Write("A compra será feita com o cartão Tabajara? (s/n): ");
            var response = char.Parse(Console.ReadLine());
            IsTabajaraCardPayment = (response == 's' || response == 'S');
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"Tipo de carne: {MeatType}");
            Console.WriteLine($"Quantidade: {Quantity} Kg");
            Console.WriteLine($"Preço total: {TotalPrice:C2}");

            if (IsTabajaraCardPayment)
            {
                var desconto = TotalPrice * 0.05;
                var precoFinal = TotalPrice - desconto;
                Console.WriteLine("Tipo de pagamento: Cartão Tabajara");
                Console.WriteLine($"Valor do desconto: {desconto:C2}");
                Console.WriteLine($"Valor a pagar: {precoFinal:C2}");
            }
            else
            {
                Console.WriteLine("Tipo de pagamento: Dinheiro");
                Console.WriteLine("Valor do desconto: R$ 0,00");
                Console.WriteLine($"Valor a pagar: {TotalPrice:C2}");
            }
        }
    }
}
