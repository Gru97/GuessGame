using GuessGame.Tests;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessGame.UI
{
    public partial class Form1 : Form
    {
        private readonly Point _initialLocation;
        private readonly GameManager _gameManager;
        private bool _pictureIsSelected;
        private const string INITIALPICTURETEXT = "Guess My Nationality?";
       
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _gameManager = new GameManager();
            _initialLocation = pictureQuestion.Location;
        }

    

        private async void btnStart_Click(object sender, EventArgs e)
        {
            _gameManager.StartRound();
            await MovePicture();
            
        }

        private async Task MovePicture()
        {

            while (!_gameManager.IsRoundFinished() )
            {
                if (_pictureIsSelected)
                    break;
                

                pictureQuestion.Location =
                    new Point(pictureQuestion.Location.X, pictureQuestion.Location.Y + 1);

                await Task.Delay(1);
            }
        }

        private void OnPictureMoved()
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location =
                    new Point(pictureQuestion.Location.X, pictureQuestion.Location.Y + 1);
            }));
        }
        private void OnPictureLocationRestarted(string correctGuess)
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location = _initialLocation;
                pictureQuestion.Text =  $"{INITIALPICTURETEXT}\n({correctGuess})";
                //gameCanvas.Refresh();
            }));

           
        }
        private void pictureQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureIsSelected = true;
            Invoke(new Action(delegate()
            {
                _gameManager.StopRound();
            }));
            
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
            pictureQuestion.Location = new Point(pictureQuestion.Location.X+ e.X, pictureQuestion.Location.Y+ e.Y);

            _pictureIsSelected = false;

            if (IsInAnyBox())
                _gameManager.PlayerGuessed(GuessedBox());

            PrepareBoardForNextRound();
            ShowScore();
            _gameManager.StartRound();
            await MovePicture();

        }

        private void PrepareBoardForNextRound()
        {
            pictureQuestion.Location = _initialLocation;
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
