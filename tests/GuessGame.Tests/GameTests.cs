using System;
using Xunit;

namespace GuessGame.Tests
{
    //A white screen with 4 boxes on the 4 corners of the screen.
    //Each box will have a text on it reading ""Japanese"", ""Chinese"", ""Korean"" and ""Thai"".
    //From the middle top of the screen, the photo of a person should drop and slowly go to the bottom of the screen within 3 seconds.
    //As the image is dropping down, the user should guess the nationality of the person before it reaches the bottom, and throw it towards one of the 4 nationality boxes by panning it (for about 20px or more). The photo should then animate towards that box and slowly fade out.
    //If the user guessed correctly, it will be a positive 20 points.If it was wrong it will be -5 points.
    //The total points should be displayed at the bottom of the screen.
    //Immediately after the picture has disappeared, the next picture should drop.
    //This should continue for 10 or more pictures and then the game will stop, showing the user's total score, with a button to play again.
    
    //game -> has a player, 10 toBeGuessed
    //Picture with nationality
    //Player -> guess, has score, 
    
   
    public class GameTests
    {
        [Fact]
        public void Should_Set_Current_Choice_For_Player_On_Each_Guess()
        {
            var player = new Player();

            player.Guess(Choice.Korean);

            Assert.Equal(Choice.Korean, player.CurrentChoice);
        }
        [Fact]
        public void Should_Generate_Question_For_Game()
        {
            var game = new Game();

            game.GenerateRandomQuestions();

            Assert.Equal(Game.MaxRound,game.Questions.Count);


        }

        [Fact]
        public void Player_Should_Get_20_Points_On_Correct_Guess()
        {
            var game = new Game();
            game.GenerateRandomQuestions();

            game.Player.Guess(Choice.Chinese);
            game.Score();

            Assert.Equal(20, game.Player.Score);
        } 
        
        [Fact]
        public void Player_Should_Lose_5_Points_On_Wrong_Guess()
        {

            var game = new Game();
            game.GenerateRandomQuestions();

            game.Player.Guess(Choice.Japanese);
            game.Score();

            Assert.Equal(-5, game.Player.Score);

        }

        [Fact]
        public void Game_Should_End_After_10_Guess()
        {
            var game=new Game();
            game.GenerateRandomQuestions();

            while (!game.End())
            {
                game.Player.Guess(Choice.Korean);
                game.Score();
            }
            
            Assert.Equal(10,game.CurrentRound);
        }

    }
}
