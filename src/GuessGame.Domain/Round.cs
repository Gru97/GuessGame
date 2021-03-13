using System;
using System.Diagnostics;

namespace GuessGame.Domain
{
    public class Round
    {
        public Choice CorrectGuess { get; private set; }
        public int RoundNumber { get; set; }
        private readonly Stopwatch _timer;
        public const int MaxTimeEachRound = 8;
        public Round()=> _timer = new Stopwatch();
        private void SetCorrectChoice()
        {
            var random = new Random();
            var randomChoice = random.Next(0, 3);
            CorrectGuess = ((Choice)randomChoice);
        }
        public void StartRound(int round)
        {
            _timer.Restart();
            SetCorrectChoice();
            RoundNumber = round;
        }
        public void StopRound()=> _timer.Stop();
        public bool TimesUp()=> _timer.Elapsed.Seconds > MaxTimeEachRound;
        public bool IsFinished() => !_timer.IsRunning;
    }
}