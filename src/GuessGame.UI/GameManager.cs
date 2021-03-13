using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using GuessGame.Domain;

namespace GuessGame.UI
{
    public class GameManager
    {
        private Game _game;
        private bool _useGuessed=false;

        public GameManager()
        {
            _game=new Game();
        }
        public void StopRound()
        {
            _game.CurrentRound.StopRound();
            _useGuessed = true;
        }
        public void PlayerGuessed(Choice choice)
        {
            _game.Player.Guess(choice);
            _game.Score();
        }

        public void NextRound()=> _game.NextRound();
        private bool TimesUp() => _game.CurrentRound.TimesUp();
        public int GetScore()=> _game.Player.Score;
        public bool IsRoundFinished() => TimesUp() || _game.CurrentRound.IsFinished();
        public string GetCorrectGuessForRound()=> _game.GetCurrentRoundRightGuess().ToString();
        public bool End() => _game.End ;
       
    }

  
}
