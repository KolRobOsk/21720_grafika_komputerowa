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
        int pacFellaSpeed, redGhostSpeed, yellowGhostSpeed, blueGhostSpeed, pinkGhostSpeed;
        int[,,] wallz;

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            checkLoseCondition();
            if (isGameOver == true) {
                gameOver();
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
            if (PacFella.Location.X - RedGhostie.Location.X <= 10 && PacFella.Location.X - RedGhostie.Location.X >= -10)
            {
                if (PacFella.Location.Y - RedGhostie.Location.Y <= 10 && PacFella.Location.Y - RedGhostie.Location.Y >= -10)
                {
                    devoured = true;
                    isGameOver = true;
                }
            }
            if (PacFella.Location.X - BlueGhostie.Location.X <= 10 && PacFella.Location.X - BlueGhostie.Location.X >= -10)
            {
                if (PacFella.Location.Y - BlueGhostie.Location.Y <= 10 && PacFella.Location.Y - BlueGhostie.Location.Y >= -10)
                {
                    devoured = true;
                    isGameOver = true;
                }
            }
            if (PacFella.Location.X - PinkGhostie.Location.X <= 10 && PacFella.Location.X - PinkGhostie.Location.X >= -10)
            {
                if (PacFella.Location.Y - PinkGhostie.Location.Y <= 10 && PacFella.Location.Y - PinkGhostie.Location.Y >= -10)
                {
                    devoured = true;
                    isGameOver = true;
                }
            }
            if (PacFella.Location.X - YellowGhostie.Location.X <= 10 && PacFella.Location.X - YellowGhostie.Location.X >= -10)
            {
                if (PacFella.Location.Y - YellowGhostie.Location.Y <= 10 && PacFella.Location.Y - YellowGhostie.Location.Y >= -10)
                {
                    devoured = true;
                    isGameOver = true;
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                foreach (int element in wallz)
                { }
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
            int iter = 0;
            foreach (var pb in this.Controls.OfType<PictureBox>())
            {
                if (pb.Tag == "wallz") 
                {
                    iter += 1;
                }
            }
            wallz = new int[iter, 2, 2];
            iter = 0;
            foreach (var pb in this.Controls.OfType<PictureBox>())
            {
                if (pb.Tag == "wallz")
                {
                    wallz[iter, 0, 0] = pb.Location.X; 
                    wallz[iter, 0, 1] = pb.Location.X + pb.Width;
                    wallz[iter, 1, 0] = pb.Location.Y;
                    wallz[iter, 1, 1] = pb.Location.Y + pb.Height;  
                }
            }
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
