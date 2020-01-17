using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    class MovingObject : GameObject {

        public MovingObject(PictureBox pictureBox, float width/*, float height*/) : base(pictureBox.Image) {
            this.pictureBox = new CustomPictureBox(pictureBox.Image);
            //size = new Vector2(width, height);
            //pictureBox.Size = Vector2.GetSize(size);
            this.width = width;
            MainHandler.instance.SizeChanged += Instance_SizeChanged;
        }

        private void Instance_SizeChanged(object sender, EventArgs e) {
            
            pictureBox.Size = this.GetSizeFromWidth();
            //Console.WriteLine($"{s.Width} / {pictureBox.Image.Width} * {pictureBox.Image.Height} = {s}");
            Move(Vector2.zero);
        }

        public void Move(Vector2 direction) {
            position += direction;
            position = position.Clamp(Vector2.zero, Vector2.one * 0.93f);
            
            pictureBox.Left = (int)(position.x * MainHandler.panelSize.Width);
            pictureBox.Top = (int)((1f - position.y) * MainHandler.panelSize.Height - pictureBox.Height);
        }
    }
}
