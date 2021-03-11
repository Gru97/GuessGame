using System.Diagnostics;
using System.Drawing;
using System.Threading;
using GuessGame.Tests;

namespace GuessGame.UI
{
    public class GameManager
    {
        private Game _game;
        private Stopwatch _timer=new Stopwatch();
        public delegate void Notify();  // delegate
        public event Notify PictureLocationRestarted; // event
        public event Notify PictureMoved; // event


        public void StartGame()
        {
            _game = new Game();
            _game.GenerateRandomQuestions();

            Thread worker = new Thread(new ThreadStart(Move));
            worker.Start();
        }

        public void PlayerGuessed(Point pictureQuestionLocation)
        {
            _game.Player.Guess(Choice.Korean);
            _game.Score();
        }
        private void Move()
        {

            while (!_game.End())
            {
                if (!_timer.IsRunning)
                {
                    _timer.Start();
                    //TODO: raise an event to reset picture location
                    PictureLocationRestarted();
                    while (!TimesUp() && _timer.IsRunning)
                    {
                        //TODO: raise an event to move picture
                        PictureMoved();
                        Thread.Sleep(10);
                        
                    }
                    _timer.Stop();
                    _timer.Reset();
                    _game.NextRound();
                }
            }
        }
        private bool TimesUp()
        {
            return _timer.Elapsed.Seconds > 10;
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
