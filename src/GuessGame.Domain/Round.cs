using System;
using System.Diagnostics;

namespace GuessGame.Domain
{
    public class Round
    {
        public Choice CorrectGuess { get; set; }
        private Stopwatch st;
        public int RoundNumber { get; set; }
        public const int MaxTimeEachRound = 8;
      
        private void SetCorrectChoice()
        {
            var random = new Random();
            var randomChoice = random.Next(0, 3);
            CorrectGuess = ((Choice)randomChoice);
        }
        public void StartRound(int round)
        {
            st = new Stopwatch();
            st.Start();
            SetCorrectChoice();
            RoundNumber = round;
        }
        public void StopRound()
        {
            st.Stop();
        }
        public bool TimesUp()=> st.Elapsed.Seconds > MaxTimeEachRound;
        public bool IsFinished() => !st.IsRunning;
    }
}