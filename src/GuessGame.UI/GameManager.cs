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
        private bool _useGuessed;

        public GameManager()
        {
            _game = new Game();

        }

        public void StartGame()
        {
            _game.GenerateRandomQuestions();

            StartRound();
        }

        public void StartRound()
        {
            Thread worker = new Thread(new ThreadStart(Move));
            worker.Start();
        }

        public void PlayerGuessed(Choice choice)
        {
            _game.Player.Guess(choice);
            _game.Score();
        }
        private void Move()
        {

            while (!_game.End())
            {
                if (!_timer.IsRunning && !_useGuessed)
                {
                    _timer.Start();
                    //TODO: raise an event to reset picture location
                    PictureLocationRestarted();
                    while (!TimesUp())
                    {
                        if (_useGuessed)
                            break;

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
            _useGuessed = true;
            _timer.Stop();
        }
    }
}
