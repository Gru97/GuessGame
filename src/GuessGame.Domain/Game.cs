namespace GuessGame.Domain
{
    public class Game
    {
        public Player Player { get; set; }
        public static int MaxRound = 2;
        public Round CurrentRound { get; set; }
        public bool End { get; set; }
      
        public Game()
        {
            Player=new Player();
            CurrentRound=new Round();
        }
        
        public void Score()
        {
            if (GuessIsCorrect())
                Player.Score += 20;
            else
                Player.Score -= 5;
        }

        private bool GuessIsCorrect() => Player.CurrentChoice == GetCurrentRoundRightGuess();
        public Choice GetCurrentRoundRightGuess() =>CurrentRound.CorrectGuess;
        public void NextRound()
        {
            var nextRoundNumber = CurrentRound.RoundNumber + 1;
            if (nextRoundNumber > MaxRound)
            {
                End = true;
                return;
            }

            CurrentRound.StartRound(nextRoundNumber);
        }
       
    }
}