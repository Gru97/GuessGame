using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using GuessGame.Tests;

namespace GuessGame.UI
{
    public class GameManager
    {
        private readonly Game _game;
        private readonly Stopwatch _timer;
        private bool _useGuessed;

        public GameManager()
        {
            _game = new Game();
            _timer = new Stopwatch();
            _game.GenerateRandomQuestions();

        }
        public void StartRound()
        {
            if (_game.End())
                return;

            _timer.Restart();
        }
        public void StopRound()
        {
            _useGuessed = true;
            _timer.Stop();
        }
        public void PlayerGuessed(Choice choice)
        {
            _game.Player.Guess(choice);
            _game.Score();
        }

        public void NextRound()=> _game.NextRound();
        private bool TimesUp()=> _timer.Elapsed.Seconds > Game.MaxTimeEachRound;
        public int GetScore()=> _game.Player.Score;
        public bool IsRoundFinished() => TimesUp() || !_timer.IsRunning ;
        public string GetCorrectGuessForRound()=> _game.GetCurrentRoundRightGuess().ToString();
        public bool End() => _game.End() ;
       
    }

  
}
