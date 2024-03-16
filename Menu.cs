using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        // this is the holy grail method without this the form shits itself and dies
        private void Menu_Load(object sender, EventArgs e) { }
        
        
        // game starting section:
        private void button1_Click(object sender, EventArgs e)
        {

            Thread thread = new Thread(Form_running);
            thread.Start();
        }
        private void Form_running()
        {
            Application.Run(new Form1());
        }

        // score board section:
        private void load_scores()
        {
            Application.Run(new ScoreBoard());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(load_scores);
            thread.Start();
        }

        // quit section:
        private void Quit_Click(object sender, EventArgs e)
        {
            
            Thread thread = new Thread(Close_game);
            thread.Start();
        }
       
        
        private void Close_game()
        {
            Application.Exit();
        }
    }
}
