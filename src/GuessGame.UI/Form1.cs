using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessGame.Domain;
using GuessGame.Tests;
using Microsoft.VisualBasic;

namespace GuessGame.UI
{
    public partial class Form1 : Form
    {
        private readonly Graphics _graphics;
        private readonly Stopwatch _timer= new Stopwatch();
        private Point _initialLocation;
        private int _currentRound=1;
        private GameManager _gameManager;
        private bool pictureQuestionIsSelected;


        public Form1()
        {
            InitializeComponent();

            //gameCanvas.Controls.Add(new Box("lblThai", gameCanvas.Location.X, gameCanvas.Location.Y));
            //gameCanvas.Controls.Add(new Box("lblChinese", gameCanvas.Location.X + 10000, gameCanvas.Location.Y));
            //gameCanvas.Controls.Add(new Box("lblJapanese", gameCanvas.Location.X, gameCanvas.Location.Y + 700));
            //gameCanvas.Controls.Add(new Box("lblKorean", gameCanvas.Location.X + 1000, gameCanvas.Location.Y + 700));

            _gameManager = new GameManager();
            _gameManager.PictureLocationRestarted+= OnPictureLocationRestarted;
            _gameManager.PictureMoved+= OnPictureMoved;


            _graphics = gameCanvas.CreateGraphics();
            _initialLocation = pictureQuestion.Location;
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
        private void OnPictureLocationRestarted()
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location = _initialLocation;
                gameCanvas.Refresh();
            }));

           
        }
        private void pictureQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            pictureQuestionIsSelected = false;
            if(IsInCorrectLocation(pictureQuestion.Location))
                _gameManager.PlayerGuessed(pictureQuestion.Location);

            //should go for next round

        }
        private bool IsInCorrectLocation(Point pictureQuestionLocation)
        {
            if (pictureQuestion.Bounds.IntersectsWith(label1.Bounds))
            {
                MessageBox.Show("Test");
            }

            return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           _gameManager.StartGame();
        }
        private void pictureQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            pictureQuestionIsSelected = true;
            Invoke(new Action(delegate()
            {
                _gameManager.Stop();
                //pause, then on mouse up starts moving down from where it's been stopped
            }));
            
        }
        private void pictureQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureQuestionIsSelected)
                pictureQuestion.Location=new Point(e.X,e.Y);
        }
    }
}
