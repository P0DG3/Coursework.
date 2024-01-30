using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace coursework
{
    public partial class Form1 : Form
    {
        int EnemyCount = 4;
        int EnemySpeed = 5;
        int Score;
        
        Image player;
        List<string> playerMovements = new List<string>();
        bool move_left, move_right, move_up, move_down, gameOver;
        int player_x = 75;
        int player_y = 75;
        int player_height = 75;
        int player_width = 75;
        int player_speed = 25;
        


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
            if (e.KeyCode == Keys.Up)
            {
                string direction = "Up";
                TearShooting(direction);
            }
            if (e.KeyCode == Keys.Down)
            {
                string direction = "Down";
                TearShooting(direction);
            }
            if (e.KeyCode == Keys.Left)
            {
                string direction = "Left";
                TearShooting(direction);
            }
            if (e.KeyCode == Keys.Right)
            {
                string direction = "Right";
                TearShooting(direction);
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

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void TearShooting(string direction)
        {
            Tear shootTear = new Tear();
            shootTear.direction = direction;
            shootTear.tearLeft = player_x + (player_width / 2);
            shootTear.tearTop = player_y + (player_height / 2);
            shootTear.spawnTear(this);
           

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //doesn't actually spawn the enemy yet (need to do some timery things probably)
        private void SpawnEnemy()
        {
            Random rnd = new Random();

            PictureBox Enemy = new PictureBox();
            Enemy.Tag = "enemy";
            Enemy.Image = Image.FromFile("sigma.png");
            Enemy.Left = rnd.Next(0, 1000);
            Enemy.Top = rnd.Next(0, 900);
            Enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(Enemy);
            

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
            player = Image.FromFile("isaac.png");
        }

        private void AnimatePlayer(int start, int end) { }
    }
}
