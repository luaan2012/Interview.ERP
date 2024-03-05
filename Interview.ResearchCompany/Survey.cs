namespace Interview.ResearchCompany
{
    public class Survey
    {
        private int[] Votes = new int[7];

        public void ReadAsnwers()
        {
            Console.WriteLine("Qual o melhor Sistema Operacional para uso em servidores?");
            Console.WriteLine("As possíveis respostas são:");
            Console.WriteLine("1- Windows Server");
            Console.WriteLine("2- Unix");
            Console.WriteLine("3- Linux");
            Console.WriteLine("4- Netware");
            Console.WriteLine("5- Mac OS");
            Console.WriteLine("6- Outro");
            Console.WriteLine("Digite os votos, digite 0 para encerrar:");

            while (true)
            {
                var answer = int.Parse(Console.ReadLine());

                if (answer == 0)
                {
                    Console.WriteLine("Enquete encerrada.");
                    break;
                }

                if (answer < 0 || answer > 6)
                {
                    Console.WriteLine("Por favor, digite um número válido entre 1 e 6.");
                    continue;
                }

                Votes[answer]++;
                Console.WriteLine("Voto computado!");
            }
        }

        public void CalculatePercentage()
        {
            var totalVotes = 0;

            foreach (var vote in Votes)
            {
                totalVotes += vote;
            }

            for (var i = 1; i < Votes.Length; i++)
            {
                var percentage = (double)Votes[i] / totalVotes * 100;
                Console.WriteLine($"Sistema Operacional {ConvertIndexForName(i)}: {Votes[i]} {percentage:0.##}%");
            }

            Console.WriteLine("------------------- ----- ---");
            Console.WriteLine($"Total {totalVotes}");
        }

        private string ConvertIndexForName(int index)
        {
            return index switch
            {
                1 => "Windows Server",
                2 => "Unix",
                3 => "Linux",
                4 => "Netware",
                5 => "Mac OS",
                6 => "Outro",
                _ => "Desconhecido"
            };
        }

        public void PrintResult()
        {
            var maxVotes = 0;
            var indexMaxVotes = 0;
            var totalVotes = 0;

            for (var i = 1; i < Votes.Length; i++)
            {
                if (Votes[i] > maxVotes)
                {
                    maxVotes = Votes[i];
                    indexMaxVotes = i;
                }
                totalVotes += Votes[i];
            }

            Console.WriteLine($"O Sistema Operacional mais votado foi o {ConvertIndexForName(indexMaxVotes)}, com {maxVotes} votos, correspondendo a {(double)maxVotes / totalVotes * 100:0.##}% dos votos.");
        }
    }
}
