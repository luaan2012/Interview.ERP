using Interview.Guess_6.Enums;

namespace Interview.Guess_6.Models
{
    public class GuessingGameControl
    {
        public class Attempt
        {
            public string PlayerCode { get; set; }
            public int AttemptNumber { get; set; }
            public DateTime Timestamp { get; set; }
            public GuessResult Result { get; set; }
        }

        public class Player
        {
            public string Name { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }
            public double WinPercentage { get; set; }
            public List<Attempt> Attempts { get; set; }
        }
    }
}
