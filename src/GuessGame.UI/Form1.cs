using GuessGame.Tests;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuessGame.UI
{
    public partial class Form1 : Form
    {
        private Point _initialLocation;
        private GameManager _gameManager;
        private bool pictureQuestionIsSelected;
       
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _gameManager = new GameManager();
            _gameManager.PictureLocationRestarted+= OnPictureLocationRestarted;
            _gameManager.PictureMoved+= OnPictureMoved;
            _initialLocation = pictureQuestion.Location;
        }

    

        private void btnStart_Click(object sender, EventArgs e)
        {
            _gameManager.StartGame();
        }

        private void OnPictureMoved()
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location =
                    new Point(pictureQuestion.Location.X, pictureQuestion.Location.Y + 1);

                gameCanvas.Refresh();
            }));
        }
        private void OnPictureLocationRestarted(string correctGuess)
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location = _initialLocation;
                pictureQuestion.Text = correctGuess;
                gameCanvas.Refresh();
            }));

           
        }
        private void pictureQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            pictureQuestionIsSelected = true;
            Invoke(new Action(delegate()
            {
                _gameManager.Stop();
            }));
            

        }
        private void pictureQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (pictureQuestionIsSelected)
                    pictureQuestion.Location = new Point(pictureQuestion.Location.X + e.X, pictureQuestion.Location.Y + e.Y);
            }

        }

        private void pictureQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            pictureQuestion.Location = new Point(pictureQuestion.Location.X+ e.X, pictureQuestion.Location.Y+ e.Y);

            pictureQuestionIsSelected = false;
            if (IsInAnyBox())
                _gameManager.PlayerGuessed(GuessedBox());

            pictureQuestion.Location = _initialLocation;
            lblScore.Text = _gameManager.GetScore().ToString();
            _gameManager.StartRound();

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
