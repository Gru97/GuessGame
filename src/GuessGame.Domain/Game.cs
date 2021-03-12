using System;
using System.Collections.Generic;

namespace GuessGame.Tests
{
    public class Game
    {
        public List<Choice> Questions { get; set; }
        public Player Player { get; set; }
        public static int MaxRound = 2;
        public static int MaxTimeEachRound = 10;
        public int CurrentRound { get; set; } = 1;

        public bool End() => MaxRound < CurrentRound;
      
        public Game()
        {
            Questions=new List<Choice>();
            Player=new Player();
        }
        public void GenerateRandomQuestions()
        {
            var random= new Random();
            for (int i = 0; i < MaxRound; i++)
            {
                var randomChoice = random.Next(0, 3);
                Questions.Add((Choice)randomChoice);
            }
            
        }

        public void Score()
        {
            if (GuessIsCorrect())
                Player.Score += 20;
            else
                Player.Score -= 5;
        }

        private bool GuessIsCorrect() => Player.CurrentChoice == GetCurrentRoundRightGuess();
        public Choice GetCurrentRoundRightGuess() => Questions[CurrentRound - 1];
        


        public void NextRound()
        {
            
            CurrentRound++;
        }
    }
}