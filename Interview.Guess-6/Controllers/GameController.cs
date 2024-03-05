using Interview.Guess_6.Enums;
using Interview.Guess_6.Models;
using Microsoft.AspNetCore.Mvc;
using static Interview.Guess_6.Models.GuessingGame;

namespace Interview.Guess_6.Controllers
{
    public class GameController : Controller
    {
        private readonly GameManager _gameManager = GameManager.GetInstance();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartGame(Difficulty difficulty, string name)
        {
            _gameManager.StartNewGame(difficulty, name);

            return RedirectToAction("PlayGame");
        }

        public IActionResult PlayGame(bool success)
        {
            var informations = new Information()
            {
                Name = _gameManager._name,
                GuessNumber = _gameManager._numerForGuess,
                AttempLeft = _gameManager._attemptsLeft,
                Success = success
            };

            TempData["Attempts"] = _gameManager.GetGameAttempts();

            return View(informations);
        }

        [HttpPost]
        public IActionResult MakeGuess(int guess)
        {
            var result = _gameManager.MakeGuess(guess);

            if (result == GuessResult.Success)
            {
                _gameManager.updatePlayWin();
                _gameManager.updatePercent();
                TempData["Message"] = "Parabens! Você acertou!";
            }
            else if(_gameManager._attemptsLeft <= 0)
            {
                _gameManager.updatePlayLoser();
                _gameManager.updatePercent();
                TempData["Message"] = "Você errou, tente novamente.";
            }
            else
            {
                TempData["Message"] = "Você errou, tente novamente.";
            }

            return RedirectToAction("PlayGame", new { Success = result == GuessResult.Success });
        }

        public IActionResult PlayerStats()
        {
            var history = _gameManager.GetHistory();

            return View(history);
        }

        [HttpGet]
        public IActionResult ClearAttempts()
        {
            _gameManager.ClearAttempts();

            return RedirectToAction("PlayGame");
        }
    }
}
