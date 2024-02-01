using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace coursework
{
    class Tear
    {
        //gonna make an abstraction of the tears from the original game-
        //by removing the sprite for them and just using some coloured pixels (will change colour and size to indicate stronger/faster tears)
        public string direction;
        public int tearLeft;
        public int tearTop;
        public bool tearCooldown = true;
        Image image = Image.FromFile("tear.png");

        private int speed = 25;
        private PictureBox tear = new PictureBox();
        private Timer tearTimer = new Timer();

        public void spawnTear(Form form)
        {
            tear.BackColor = Color.Transparent;
            tear.Size = new Size(25,23);
            tear.Tag = "tear";
            tear.Top = tearTop;
            tear.Left = tearLeft;
            tear.BringToFront();
            tear.Image = image;
            

            form.Controls.Add(tear);

            tearTimer.Interval = speed;
            tearTimer.Tick += new EventHandler(tearTimerEvent);
            tearTimer.Start();
        }


        private void tearTimerEvent(object sender, EventArgs e)
        {
            //changes the displacement of the tear sprite using the 'speed' variable to update the location of the top and the left of the picture picture box
            if (direction == "Up")
            {
                tear.Top -= speed;
            }
            else if (direction == "Down")
            {
                tear.Top += speed;
            }
            else if(direction == "Left")
            {
                tear.Left -= speed;
            }
            else if(direction == "Right")
            {
                tear.Left += speed;
            }
            

            //despawn tear and its timer when tear hits any of the edges edges of screen
            // sets the tear and its timer to null (being memory efficient waow) 
            if (tear.Top < 50 || tear.Top > 950  || tear.Left < 50 || tear.Left > 1800 )
            {
                tearTimer.Stop();
                tearTimer.Dispose();
                tear.Dispose();
                tearTimer = null;
                tear = null;
                
            }
                
        }
    }
}

