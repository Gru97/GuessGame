using System.Collections.Generic;

namespace GuessGame.Tests
{
    public class Game
    {
        public List<Choice> Questions { get; set; }
        public Player Player { get; set; }
        public static int QuestionCount = 10;
        public int CurrentRound { get; set; }

        public bool End() => QuestionCount == CurrentRound;
      
        public Game()
        {
            Questions=new List<Choice>();
            Player=new Player();
        }
        public void GenerateRandomQuestions()
        {
            //var random= new Random();
            for (int i = 0; i < QuestionCount; i++)
            {
                //var r= random.Next(0, 3);
                var randomChoice = 1;
                Questions.Add((Choice)randomChoice);
            }
            
        }

        public void Score()
        {
            if (Player.CurrentChoice == Questions[CurrentRound-1])
                Player.Score += 20;
            else
                Player.Score -= 5;

            NextRound();
        }


        public void NextRound()
        {
            CurrentRound++;
        }
    }
}