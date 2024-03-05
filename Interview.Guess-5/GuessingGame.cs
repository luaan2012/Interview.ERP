namespace Interview.Guess_5
{
    public class GuessingGame
    {
        private int NumberToGuess;
        private int AttemptsLeft = 5;
        private int Dificult = 3;

        public GuessingGame()
        {
            Random random = new Random();
            NumberToGuess = random.Next(1, 11);
        }

        public void Start()
        {
            Console.WriteLine("Bem-Vindo ao jogo de adivinhação!");
            Console.WriteLine("Tente acerta o número de 1 a 10.");
            Console.WriteLine($"Você tem {AttemptsLeft} restantes.");

            while (AttemptsLeft > 0)
            {
                Console.Write("Digite seu número: ");
                int guess = int.Parse(Console.ReadLine());

                if (guess == NumberToGuess)
                {
                    Console.WriteLine("Parabens! Você acertou!");
                    return;
                }
                else if (Math.Abs(guess - NumberToGuess) <= Dificult / 2)
                {
                    Console.WriteLine("Você está quente! Tente novamente.");
                }
                else if (guess < Dificult)
                {
                    Console.WriteLine("Está longe! Tente novamente.");
                }
                else
                {
                    Console.WriteLine("Está longe! Tente novamente.");
                }

                AttemptsLeft--;
                Console.WriteLine($"Tentativas restantes: {AttemptsLeft}");
            }

            Console.WriteLine("Acabou as chances! você usou todas tentativas.");
            Console.WriteLine($"O número correto era: {NumberToGuess}");
        }
    }
}
