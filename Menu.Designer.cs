namespace coursework
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.quit = new System.Windows.Forms.Button();
            this.leaderboard = new System.Windows.Forms.Button();
            this.newgame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::coursework.Properties.Resources.BigPartOfMenu;
            this.pictureBox1.Location = new System.Drawing.Point(854, 329);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 218);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // quit
            // 
            this.quit.Image = global::coursework.Properties.Resources.Quit;
            this.quit.Location = new System.Drawing.Point(866, 641);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(182, 38);
            this.quit.TabIndex = 3;
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // leaderboard
            // 
            this.leaderboard.Image = global::coursework.Properties.Resources.Scores;
            this.leaderboard.Location = new System.Drawing.Point(866, 597);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Size = new System.Drawing.Size(182, 38);
            this.leaderboard.TabIndex = 2;
            this.leaderboard.UseVisualStyleBackColor = true;
            this.leaderboard.Click += new System.EventHandler(this.button2_Click);
            // 
            // newgame
            // 
            this.newgame.BackColor = System.Drawing.Color.Black;
            this.newgame.BackgroundImage = global::coursework.Properties.Resources.NewGame;
            this.newgame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newgame.Location = new System.Drawing.Point(866, 553);
            this.newgame.Name = "newgame";
            this.newgame.Size = new System.Drawing.Size(182, 38);
            this.newgame.TabIndex = 1;
            this.newgame.Text = "\r\n";
            this.newgame.UseVisualStyleBackColor = false;
            this.newgame.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::coursework.Properties.Resources._1e1e1e_colour;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.leaderboard);
            this.Controls.Add(this.newgame);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "Menu";
            this.Text = "Menu";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newgame;
        private System.Windows.Forms.Button leaderboard;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}