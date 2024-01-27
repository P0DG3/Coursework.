using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class Form1 : Form
    {
        
        
        Image player;
        List<string> playerMovements = new List<string>();
        bool move_left, move_right, move_up, move_down;
        float player_x = 75;
        float player_y = 75;
        int player_height = 75;
        int player_width = 75;
        float player_speed = 25;


        public Form1()
        {
            InitializeComponent();
            SetUp();
        }

        private void TimerEvent(object sender, EventArgs e)
        {

            //check if the player is touching the boundary on the left
            if (move_left && player_x > 125)
            {
                player_x -= player_speed;
            }
            // the right
            else if (move_right && player_x + player_width + 125 < this.ClientSize.Width)
            {
                player_x += player_speed;
            }
            //the top
            else if (move_up && player_y > 125)
            {
                player_y -= player_speed;
            }
            //the bottom
            else if (move_down && player_y + player_height +125 < this.ClientSize.Height)
            {
                player_y += player_speed;
            }
            this.Invalidate();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                move_left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                move_right = true;
            }
            if (e.KeyCode == Keys.W)
            {
                move_up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                move_down = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                move_left = false;
            }
           
            else if (e.KeyCode == Keys.D)
            {
                move_right = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                move_up = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                move_down = false;
            }
        }

        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(player, player_x, player_y, player_height, player_width);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        

        private void SetUp()
        {
            //set initial background image (tutorial with controls on screen)
            this.BackgroundImage = Image.FromFile("background1.png.");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //'DoubleBuffered' makes the animation of the player look smoother
            this.DoubleBuffered = true;
            //load player files into a list
            playerMovements = Directory.GetFiles("player", "*.png").ToList();
            player = Image.FromFile("doom.png");
        }

        private void AnimatePlayer(int start, int end) { }
    }
}
