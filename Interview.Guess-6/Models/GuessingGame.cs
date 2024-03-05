using Interview.Guess_6.Enums;

namespace Interview.Guess_6.Models
{
    public class GuessingGame
    {
        
        public class Attempt
        {
            public string PlayerCode { get; set; }
            public int AttemptNumber { get; set; }
            public DateTime Timestamp { get; set; }
            public GuessResult Result { get; set; }
        }

        public class GameHistory
        {
            public string PlayerCode { get; set; }
            public int AttemptNumber { get; set; }
            public int Wins { get; set; }
            public int Losers { get; set; }
            public double PorcentVitory { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public class Information
        {
            public string Name { get; set; }
            public int GuessNumber { get; set; }
            public int AttempLeft { get; set; }
            public bool Success { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public class GameManager
        {
            private static GameManager _instance;
            private readonly List<Attempt> _attempts = new();
            private readonly List<GameHistory> _gameHistory = [];
            private readonly Dictionary<Difficulty, int> _difficulty = new()
            {
                { Difficulty.Easy, 5 },
                { Difficulty.Medium, 10 },
                { Difficulty.Hard, 15 }
            };

            private readonly Dictionary<Difficulty, int> _attemptsDificult = new Dictionary<Difficulty, int>
            {
                { Difficulty.Easy, 10 },
                { Difficulty.Medium, 20 },
                { Difficulty.Hard, 30 }
            };

            private int _playerWins;
            private int _playerLosses;
            private int _numberToGuess;
            public int _maxAttempts;
            public int _attemptsLeft;
            public int _numerForGuess;
            public string _name;
            public bool _newGame;

            private GameManager() { }

            public static GameManager GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }

            public void StartNewGame(Difficulty difficulty, string name)
            {
                Random random = new();
                _numberToGuess = random.Next(1, _attemptsDificult[difficulty]);
                _playerWins = 0;
                _playerLosses = 0;
                _maxAttempts = _difficulty[difficulty];
                _attemptsLeft = _maxAttempts;
                _numerForGuess = _attemptsDificult[difficulty];
                _name = name;
                _newGame = true;
            }

            public GuessResult MakeGuess(int guess)
            {
                var result = guess == _numberToGuess ? GuessResult.Success : GuessResult.Wrong;

                var player = _gameHistory.Find(p => p.PlayerCode == _name);

                _attempts.Add(new Attempt()
                {
                    PlayerCode = _name,
                    AttemptNumber = guess,
                    Timestamp = DateTime.Now,
                    Result = guess == _numberToGuess ? GuessResult.Success : GuessResult.Wrong,
                });

                if (player is null)
                {
                    _gameHistory.Add(new GameHistory
                    {
                        PlayerCode = _name,
                        Timestamp = DateTime.Now,
                    });
                }

                _attemptsLeft -= 1;

                return result;
            }

            public IReadOnlyList<GameHistory> GetGameHistory()
            {
                return _gameHistory.Where(a => a.PlayerCode == _name).ToList();
            }

            public IEnumerable<Attempt> GetGameAttempts()
            {
                return _attempts.Where(a => a.PlayerCode == _name);
            }

            public IEnumerable<GameHistory> GetHistory()
            {
                return _gameHistory;
            }

            public void ClearAttempts()
            {
                _attempts.Clear();
            }

            public void updatePlayWin()
            {
                var player = _gameHistory.Find(p => p.PlayerCode == _name);

                player.Wins++;
            }

            public void updatePlayLoser()
            {
                var player = _gameHistory.Find(p => p.PlayerCode == _name);

                player.Losers++;
            }

            public void updatePercent()
            {
                var player = _gameHistory.Find(p => p.PlayerCode == _name);

                player.PorcentVitory = ((double)player.Wins / (player.Wins + player.Losers)) * 100;
            }
        }
    }
}
