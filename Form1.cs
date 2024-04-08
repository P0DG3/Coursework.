using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace coursework
{
    public partial class Form1 : Form
    {
        int TearCooldown = 0;
<<<<<<< Updated upstream
        public static int Score = 0;
        
        Image background = Image.FromFile("tutorialRoom.png");
=======
        int Score;
        //Player stuff
>>>>>>> Stashed changes
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
            EnemySystem();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            int EnemySpeed = 5;
            TearCooldown -= 1;
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
            else if (move_down && player_y + player_height + 125 < this.ClientSize.Height)
            {
                player_y += player_speed;
            }

            //moves the enemy towards the player (looks buggy but it works) 
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (x.Left > player_x)
                    {
                        x.Left -= EnemySpeed;
                    }
                    if (x.Left < player_x)
                    {
                        x.Left += EnemySpeed;
                    }
                    if (x.Top > player_y)
                    {
                        x.Top -= EnemySpeed;
                    }
                    if (x.Top < player_y)
                    {
                        x.Top += EnemySpeed;
                    }
                }
            }
                PlayerCollision();
                TearCollision();
                Invalidate();
        }
        //despawns the tears and the enemies when they collide
        public void TearCollision()
        {

            foreach (Control control in Controls)
            {
                foreach (Control x in Controls)
                {
                    if (control is PictureBox && (string)control.Tag == "tear" && x is PictureBox && (string)x.Tag == "enemy")
                    {
                        if (control.Bounds.IntersectsWith(x.Bounds))
                        {
                            Controls.Remove(control);
                            ((PictureBox)control).Dispose();
                            Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            Score += 100;
                        }
                    }
                }
            }
        }

        public void PlayerCollision()
        {
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (Get_Player_Hitbox().IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        Invalidate();
                        GameOver();
                    }
                }
            }
        }
        private void GameOver()
        {
            //write score to file
            
            System.IO.File.WriteAllText("Scores.txt", Score + Environment.NewLine); 

            new Thread(() => Application.Run(new GameOver(Score))).Start();
            Close();
        }
        private Rectangle Get_Player_Hitbox()
        {
            //this is the hitbox for the player
            Rectangle playerHitbox = new Rectangle(player_x, player_y, player_width, player_height);
            return playerHitbox;
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

<<<<<<< Updated upstream
        private void timer2_Tick(object sender, EventArgs e)
        {}
=======



>>>>>>> Stashed changes

        private void TearShooting(string direction)
        {
            if (TearCooldown <= 0)
            {

                Tear shootTear = new Tear();

                shootTear.direction = direction;
                shootTear.tearLeft = player_x + (player_width / 2);
                shootTear.tearTop = player_y + (player_height / 2);
                TearCooldown = 5;
                shootTear.spawnTear(this);
            }
        }

        //system for spawning enemies (will be tweaked later to not spawn them in the starting room)
        public void EnemySystem()
        {
            bool moreEnemies = true;
            int EnemyCount = 4;
            while (moreEnemies)
            {
                Random rnd = new Random();
                int i = 0;
                while (i < EnemyCount)
                {
                    //define the enemy and its properties
                    PictureBox Enemy = new PictureBox
                    {
                        Tag = "enemy",
                        BackColor = Color.Transparent,
                        Image = Image.FromFile("clotty.png"),
                        Left = rnd.Next(125, 1000),
                        Top = rnd.Next(125, 900),
                        SizeMode = PictureBoxSizeMode.AutoSize
                    };
                    Controls.Add(Enemy);
                    i++;
                }
                moreEnemies = false;
            }
        }







            private void SetUp()
        {
            //set initial background image (tutorial with controls on screen)
            BackgroundImage = background;
            BackgroundImageLayout = ImageLayout.Stretch;
            //'DoubleBuffered' makes the animation of the player look smoother (not animated yet)
            DoubleBuffered = true;
            //load player files into a list
            playerMovements = Directory.GetFiles("player", "*.png").ToList();
            player = Image.FromFile("isaac.png");
<<<<<<< Updated upstream
            Score = 0;
=======
>>>>>>> Stashed changes
        }
    }
}
