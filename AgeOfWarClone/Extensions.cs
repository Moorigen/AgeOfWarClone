using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    static class Extensions {
        public static float Clamp(this float f, float min, float max) {
            if (f < min) {
                return min;
            } else if (f > max) {
                return max;
            } else {
                return f;
            }
        }

        public static Vector2 Clamp(this Vector2 v, Vector2 min, Vector2 max) {
            v.x = v.x.Clamp(min.x, max.x);
            v.y = v.y.Clamp(min.y, max.y);
            return v;
        }

        public static T AddComponent<T>(this GameObject gameObject) {
            Type type = typeof(T);
            try {
                object obj = type.GetConstructor(new Type[] { typeof(GameObject) }).Invoke(new object[] { gameObject });
                return (T)obj;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public static T GetComponent<T>(this GameObject gameObject) {
            foreach (var behavior in gameObject.behaviors) {
                if (behavior.GetType().Equals(typeof(T))) {
                    return (T)Convert.ChangeType(behavior, typeof(T));
                }
            }
            return default(T);
        }

        public static Size GetSizeFromWidth(this GameObject go) {
            Size s = Vector2.GetSize(new Vector2(go.width, 1f));
            s.Height = (int)(((float)s.Width / go.pictureBox.Image.Width) * go.pictureBox.Image.Height);
            return s;
        }
    }
}
