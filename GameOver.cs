using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class GameOver : Form
    {
        int Score;
        public GameOver(int score)
        {
            Score = score;
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            
            
            RichTextBox EndCard = new RichTextBox();
            EndCard.Text = "Game Over";
            EndCard.Text += "\n";
            EndCard.Text += "score: " + Score;
            EndCard.Location = new Point(150, 50);
            EndCard.Size = new Size(500, 500);
            EndCard.Font = new Font("IsaacGame", 14);
            EndCard.ReadOnly = true;
            this.Controls.Add(EndCard);
            this.Load += GameOver_Load;
            

            string[] scores = System.IO.File.ReadAllLines("Scores.txt");
            int[] intScores = new int[scores.Length];
            for (int i = 0; i < scores.Length; i++)
            {
                intScores[i] = int.Parse(scores[i]);
            }
            for (int i = 0; i < intScores.Length - 1; i++)
            {
                for (int j = 0; j < intScores.Length - 1; j++)
                {
                    if (intScores[j] < intScores[j + 1])
                    {
                        int temp = intScores[j];
                        intScores[j] = intScores[j + 1];
                        intScores[j + 1] = temp;
                    }
                }
            }
            System.IO.File.WriteAllText("Scores.txt", "");
        }
    }
}
