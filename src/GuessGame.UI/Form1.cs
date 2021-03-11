using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
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
        private Point _initialLocation;
        private GameManager _gameManager;
        private bool pictureQuestionIsSelected;
       
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //g.DrawRectangle(new Pen(Color.Aquamarine),new Rectangle(new Point(400,20),new Size(120,120)));
            //gameCanvas.Controls.Add(new Box("lblThai", gameCanvas.Location.X, gameCanvas.Location.Y));
            //gameCanvas.Controls.Add(new Box("lblChinese", gameCanvas.Location.X + 10000, gameCanvas.Location.Y));
            //gameCanvas.Controls.Add(new Box("lblJapanese", gameCanvas.Location.X, gameCanvas.Location.Y + 700));
            //gameCanvas.Controls.Add(new Box("lblKorean", gameCanvas.Location.X + 1000, gameCanvas.Location.Y + 700));

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
        private void OnPictureLocationRestarted()
        {
            Invoke(new Action(delegate()
            {
                pictureQuestion.Location = _initialLocation;
                gameCanvas.Refresh();
            }));

           
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
    
        private void pictureQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            pictureQuestion.Location = new Point(pictureQuestion.Location.X+ e.X, pictureQuestion.Location.Y+ e.Y);

            pictureQuestionIsSelected = false;
            if (IsInAnyBox())
                _gameManager.PlayerGuessed(GuessedBox());

            //_gameManager.StartRound();

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

        private void pictureQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (pictureQuestionIsSelected)
                    pictureQuestion.Location = new Point(pictureQuestion.Location.X + e.X, pictureQuestion.Location.Y + e.Y);
            }
           
        }
    }
}
