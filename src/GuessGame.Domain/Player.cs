namespace GuessGame.Domain
{
    public class Player
    {
        public Choice CurrentChoice { get; private set; }
        public int Score { get; set; }

        public void Guess(Choice currentChoice)
        {
            CurrentChoice = currentChoice;
        }

    }
}