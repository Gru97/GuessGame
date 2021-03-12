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

        public void PlayerGuessed(Choice choice)
        {
            _game.Player.Guess(choice);
            _game.Score();
        }
      
        private bool TimesUp()
        {
            return _timer.Elapsed.Seconds > Game.MaxTimeEachRound;
        }

        public void StopRound()
        {
            _useGuessed = true;
            _timer.Stop();
        }

        public int GetScore()
        {
            return _game.Player.Score;
        }

        public bool IsRoundFinished()
        {
            return !_timer.IsRunning && !TimesUp();
        }

        public void StartRound()
        {
            
            _timer.Restart();
        }

      
    }

  
}
