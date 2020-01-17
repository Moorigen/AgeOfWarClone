namespace AgeOfWarClone {
    partial class MainHandler {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainHandler));
            this.playerImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // playerImage
            // 
            this.playerImage.BackColor = System.Drawing.Color.Transparent;
            this.playerImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playerImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerImage.Enabled = false;
            this.playerImage.Image = ((System.Drawing.Image)(resources.GetObject("playerImage.Image")));
            this.playerImage.Location = new System.Drawing.Point(282, 231);
            this.playerImage.Name = "playerImage";
            this.playerImage.Size = new System.Drawing.Size(66, 83);
            this.playerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerImage.TabIndex = 4;
            this.playerImage.TabStop = false;
            this.playerImage.Visible = false;
            // 
            // MainHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.playerImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainHandler";
            this.ShowIcon = false;
            this.Text = "A Gameu!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.ResizeGame);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyReleased);
            this.Resize += new System.EventHandler(this.ResizeGame);
            ((System.ComponentModel.ISupportInitialize)(this.playerImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox playerImage;
    }
}

