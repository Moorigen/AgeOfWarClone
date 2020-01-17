using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    class CustomPictureBox : PictureBox {
        
        public PictureBox overlay;

        public CustomPictureBox() {
            this.BackColor = Color.Transparent;

            overlay = new PictureBox();
            overlay.BackColor = Color.Transparent;
            overlay.Size = Size;
            Controls.Add(overlay);

            this.SizeChanged += (sender, e) => {
                overlay.Size = Size;
            };
        }

        public CustomPictureBox(Image image) {
            this.BackColor = Color.Transparent;
            this.Image = image;
            this.SizeMode = PictureBoxSizeMode.Zoom;

            overlay = new PictureBox();
            overlay.BackColor = Color.Transparent;
            Controls.Add(overlay);

            this.SizeChanged += (sender, e) => {
                overlay.Size = Size;
            };
        }

        public void SetTint(Color col) {
            overlay.BackColor = col;
        }
    }
}
