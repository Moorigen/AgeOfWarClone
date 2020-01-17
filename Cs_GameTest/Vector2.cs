using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    class Vector2 {
        public float x, y;

        public Vector2() { }

        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right) {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        public static Size operator *(Size left, Vector2 right) {
            return new Size((int)(left.Width * right.x), (int)(left.Height * right.y));
        }

        public static Vector2 operator *(Vector2 left, float right) {
            return new Vector2(left.x * right, left.y * right);
        }

        public static readonly Vector2 zero = new Vector2(0f, 0f);
        public static readonly Vector2 one = new Vector2(1f, 1f);
        public static readonly Vector2 right = new Vector2(1f, 0f);

        public static Size GetSize(Vector2 v2) {
            //Console.WriteLine($"window size: {MainHandler.instance.windowSize}, v2: {v2}");
            return new Size((int)(v2.x * MainHandler.windowSize.Width), (int)(v2.y * MainHandler.windowSize.Height));
        }

        public override bool Equals(object obj) {
            Vector2 v2 = (Vector2)obj;
            if (v2 is object && v2.x.Equals(x) && v2.y.Equals(y)) return true;
            else return false;
        }

        public override string ToString() {
            return $"({x},{y})";
        }
    }
}
