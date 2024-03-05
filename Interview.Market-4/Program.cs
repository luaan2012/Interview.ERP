using Interview.Market_4;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

Console.WriteLine(@"
    - Até 5 Kg | Acima de 5 Kg
    - File Duplo R$ 4,90 por Kg | R$ 5,80 por Kg
    - Alcatra R$ 5,90 por Kg | R$ 6,80 por Kg
    - Picanha R$ 6,90 por Kg | R$ 7,80 por Kg

");
Console.WriteLine();
Console.WriteLine("Bem-vindo ao Mercado XXXXXXX!");
Console.WriteLine("Promoção de Carnes:");
Console.WriteLine("1 - File Duplo");
Console.WriteLine("2 - Alcatra");
Console.WriteLine("3 - Picanha");
Console.Write("Escolha o tipo de carne (1, 2 ou 3): ");
var meatType = int.Parse(Console.ReadLine());

Console.Write("Digite a quantidade em Kg: ");
var quantity = double.Parse(Console.ReadLine());

ShoppingCart cart = new(meatType, quantity);
cart.GenerateReceipt();

Console.WriteLine("\nCupom Fiscal:");
cart.PrintReceipt();