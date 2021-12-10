using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Gra_21720
{
    public partial class PacMan_21720 : Form
    {
        bool goUp, goDown, goLeft, goRight, isGameOver, devoured;
        int pacFellaSpeed, redGhostSpeed, yellowGhostSpeed, blueGhostSpeed, pinkGhostSpeed, howManyWalls, checkX1, checkY1, checkX2, checkY2;

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            checkLoseCondition();
            if (isGameOver == true) {
                gameOver();
            }

            foreach (Control obj in this.Controls) 
            {
                if (obj.Bounds.IntersectsWith(PacFella.Bounds))
                {
                    if (obj.Tag.Equals("wallz"))
                    {
                        if (obj.Location.X <= PacFella.Location.X && obj.Location.X + obj.Size.Width >= PacFella.Location.X + PacFella.Size.Width) 
                        {
                            if (obj.Location.Y <= PacFella.Location.Y - pacFellaSpeed && obj.Location.Y + obj.Size.Width >= PacFella.Location.Y + PacFella.Size.Height - pacFellaSpeed)
                            {
                                goUp = false;
                            }
                            if (obj.Location.Y <= PacFella.Location.Y + pacFellaSpeed && obj.Location.Y + obj.Size.Width >= PacFella.Location.Y + PacFella.Size.Height + pacFellaSpeed)
                            {
                                goDown = false;
                            }
                        }
                    }
                }
            }

            if (goUp == true)
            {
                PacFella.Location = new Point(PacFella.Location.X, PacFella.Location.Y - pacFellaSpeed);
            }
            if (goDown == true)
            {
                PacFella.Location = new Point(PacFella.Location.X, PacFella.Location.Y + pacFellaSpeed);

            }
            if (goRight == true)
            {
                PacFella.Location = new Point(PacFella.Location.X + pacFellaSpeed, PacFella.Location.Y);
            }
            if (goLeft == true)
            {
                PacFella.Location = new Point(PacFella.Location.X - pacFellaSpeed, PacFella.Location.Y);

            }
        }

        public PacMan_21720()
        {
            InitializeComponent();
            resetGame();
        }

        private void checkLoseCondition()
        {
            if (PacFella.Bounds.IntersectsWith(RedGhostie.Bounds))
            {
                devoured = true;
                isGameOver = true;
            }
            if (PacFella.Bounds.IntersectsWith(PinkGhostie.Bounds))
            {
                devoured = true;
                isGameOver = true;
            }
            if (PacFella.Bounds.IntersectsWith(BlueGhostie.Bounds))
            {
                devoured = true;
                isGameOver = true;
            }
            if (PacFella.Bounds.IntersectsWith(YellowGhostie.Bounds))
            {
                devoured = true;
                isGameOver = true;
            }

        }



        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true; 
            }
            
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right )
            {
                goRight = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

        private void resetGame() 
        {
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            blueGhostSpeed = 5;
            pinkGhostSpeed = 5;
            pacFellaSpeed = 8;
            isGameOver = false;
            BlueGhostie.Location = new Point(449, 281);
            RedGhostie.Location = new Point(520, 256);
            YellowGhostie.Location = new Point(592, 256);
            PinkGhostie.Location = new Point(658, 277);
            PacFella.Location = new Point(561, 571);
            devoured = false;
            howManyWalls = 0;
        }

        private void gameOver()
        {
            if (devoured == true)
            {
                PacFella.Visible = false;
                var formPopup = new Form();
                formPopup.Text = "Wygrałeś!";
                formPopup.Show(this);
            }
            else {
                var formPopup = new Form();
                formPopup.Text = "Przegrałeś!";
                formPopup.Show(this);
            }
            this.Close();
        }

        private void mainGameTimer(object sender, EventArgs e)
        {

        }
    }

}
