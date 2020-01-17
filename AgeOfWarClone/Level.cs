using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    class Level {

        public Color backgroundColor;

        public List<GameObject> objects = new List<GameObject>();

        private int level;

        public Level(int level) {
            this.level = level;
            Random random = Program.random;
            backgroundColor = Color.FromArgb( (int)(random.NextDouble() * 255), (int)(random.NextDouble() * 255), (int)(random.NextDouble() * 255));
        }

        public void GenerateObjects(float spawnRate) {
            Random random = Program.random;
            float leftMostPosition = 0f;
            while (random.NextDouble() < spawnRate && leftMostPosition < 0.85f || objects.Count == 0) {
                float pos = leftMostPosition + (float)random.NextDouble() * 0.85f;
                if (pos >= 0.85f) pos = 0.85f;
                leftMostPosition = pos + 0.15f;
                GameObject go = new GameObject(Image.FromFile(Program.resourcePath + "Diablo.jpg"), pos, 0f, 0.1f);
                objects.Add(go);
                go.AddComponent<Collider>().SetColliderValues(0.1f, 0.1f, 0, level, (obj) => {
                    go.pictureBox.SetTint(Color.FromArgb(100, Color.Red));
                    go.hasToRedraw = true;
                    DrawingSystem.instance.Redraw(level);
                }, (obj) => {
                    go.pictureBox.SetTint(Color.Transparent);
                    go.hasToRedraw = true;
                    DrawingSystem.instance.Redraw(level);
                });
            }
        }
    }
}
