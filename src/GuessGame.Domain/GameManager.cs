using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GuessGame.Domain
{
    public class GameManager
    {
        private Game _game;
        private Stopwatch _timer;

        public void StartGame()
        {
            _game = new Game();
            
            Thread worker = new Thread(new ThreadStart(Move));
            worker.Start();
        }

        public void PlayerGuessed()
        {
            _game.Player.Guess(Choice.Korean);
            _game.Score();
        }
        private void Move()
        {

            while (!_game.End)
            {
                if (!_timer.IsRunning)
                {
                    _timer.Start();
                    //TODO: raise an event to reset picture location
                    while (!TimesUp())
                    {
                        //TODO: raise an event to move picture

                        Thread.Sleep(10);
                        
                    }
                    _timer.Stop();
                    _timer.Reset();
                }
            }
        }
        private bool TimesUp()
        {
            return _timer.Elapsed.Seconds > 10;
        }
    }
}
