using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessGame.Domain;

namespace GuessGame.UI
{
    public partial class Form1 : Form
    {
        private readonly Point _initialLocation;
        private  GameManager _gameManager;
        private bool _pictureIsSelected;
        private const string INITIALPICTURETEXT = "Guess My Nationality?";
       
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _initialLocation = pictureQuestion.Location;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            _gameManager = new GameManager();
            pictureQuestion.Enabled = true;
            await MovePictureForCurrentRound();
        }

        private async Task MovePictureForCurrentRound()
        {
            while (!_gameManager.End() && !_pictureIsSelected)
            {
                _gameManager.NextRound();
                PrepareBoardForCurrentRound();

                while (!_gameManager.IsRoundFinished() && !_pictureIsSelected)
                {
                    MovePictureOneStep();
                    await Task.Delay(1);
                }
                RoundFinishedWithoutGuess();
            }
            if (_gameManager.End() && !_pictureIsSelected)
            {
                ShowScore();
                MessageBox.Show("Game End!");
                ResetBoard();
            }

        }

        private void RoundFinishedWithoutGuess()
        {
            if(!_pictureIsSelected)
                _gameManager.NextRound();
        }

        private void MovePictureOneStep()
        {
            pictureQuestion.Location =
                new Point(pictureQuestion.Location.X, pictureQuestion.Location.Y + 1);
        }

        private void pictureQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureIsSelected = true;
            _gameManager.StopRound();

        }
        private void pictureQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_pictureIsSelected)
                    pictureQuestion.Location = new Point(pictureQuestion.Location.X + e.X, pictureQuestion.Location.Y + e.Y);
            }

        }
        private async void pictureQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            if (_pictureIsSelected)
            {
                pictureQuestion.Location = new Point(pictureQuestion.Location.X + e.X, pictureQuestion.Location.Y + e.Y);

                _pictureIsSelected = false;

                if (IsInAnyBox())
                {
                    _gameManager.PlayerGuessed(GuessedBox());
                    ShowScore();
                    _gameManager.NextRound();
                }
                await MovePictureForCurrentRound();
            }
        }
        private void PrepareBoardForCurrentRound()
        {
            pictureQuestion.Location = _initialLocation;
            pictureQuestion.Text = $"{INITIALPICTURETEXT}\n({_gameManager.GetCorrectGuessForRound()})";

        }
        private void ResetBoard()
        {
            pictureQuestion.Text = $"{INITIALPICTURETEXT})";
            pictureQuestion.Location = _initialLocation;
            lblScore.Text = "0";

        }
        private void ShowScore()
        {
            lblScore.Text = _gameManager.GetScore().ToString();
        }
        private Choice GuessedBox()
        {
            if (pictureQuestion.Bounds.IntersectsWith(lblChinese.Bounds)) return Choice.Chinese;
            else if (pictureQuestion.Bounds.IntersectsWith(lblJapanese.Bounds)) return Choice.Japanese;
            else if (pictureQuestion.Bounds.IntersectsWith(lblKorean.Bounds)) return Choice.Korean;
            else return Choice.Thai;
            
        }
        private bool IsInAnyBox()
        {
            if (pictureQuestion.Bounds.IntersectsWith(lblChinese.Bounds)
                || pictureQuestion.Bounds.IntersectsWith(lblJapanese.Bounds)
                || pictureQuestion.Bounds.IntersectsWith(lblKorean.Bounds)
                || pictureQuestion.Bounds.IntersectsWith(lblThai.Bounds))
                return true;

            return false;
        }

    }
}
