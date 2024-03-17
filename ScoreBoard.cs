using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class ScoreBoard : Form
    {
        public ScoreBoard()
        {
            InitializeComponent();
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            // reads the scores from the file and displays them in the rich text box 
            // it sets a bunch of properties for the rich text box i.e. location, size, font, read only
            System.IO.File.ReadAllText("Scores.txt");
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = System.IO.File.ReadAllText("Scores.txt");
            richTextBox.Location = new Point(150, 50);
            richTextBox.Size = new Size(500, 500);
            richTextBox.Font = new Font("IsaacGame", 14);
            richTextBox.ReadOnly = true;
            this.Controls.Add(richTextBox);
            this.Load += ScoreBoard_Load;
        }
    }
}
