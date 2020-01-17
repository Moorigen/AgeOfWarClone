using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    class GameObject {
        public CustomPictureBox pictureBox;

        public Vector2 position = Vector2.zero;
        //public Vector2 size = Vector2.one;
        public float width;

        public List<Behavior> behaviors = new List<Behavior>();

        public bool hasToRedraw = true;

        public GameObject(Image image) {
            pictureBox = new CustomPictureBox(image);
        }

        public GameObject(Image image, Vector2 position) {
            pictureBox = new CustomPictureBox(image);
            this.position = position;
        }

        public GameObject(Image image, float x, float y) {
            pictureBox = new CustomPictureBox(image);
            position = new Vector2(x, y);
        }

        public GameObject(Image image, Vector2 position, float width) {
            pictureBox = new CustomPictureBox(image);
            this.position = position;
            //this.size = size;
            this.width = width;
        }

        public GameObject(Image image, float x, float y, float width) {
            pictureBox = new CustomPictureBox(image);
            position = new Vector2(x, y);
            //size = new Vector2(width, height);
            this.width = width;
        }
    }
}
