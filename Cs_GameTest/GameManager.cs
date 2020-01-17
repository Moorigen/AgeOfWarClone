using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    class GameManager {

        public static readonly int levelCount = 8;

        public static GameManager instance;

        public Level[] levels = new Level[levelCount];


        public int gold = 0;
        private float goldCounter = 0f;

        public GameManager() {
            instance = this;

            for (int i = 0; i < levelCount; i++) {
                levels[i] = new Level(i);
                if (i == 0) {
                    levels[i].objects.Add(new GameObject(Image.FromFile(Program.resourcePath + "gear.png"), 0f, 0f, 0.1f));
                    levels[i].objects.Add(new GameObject(Image.FromFile(Program.resourcePath + "gear.png"), 0.9f, 0f, 0.1f));
                } else {
                    levels[i].GenerateObjects(i / 10f);
                }
                //RedrawFull(i);
            }

            MainHandler.instance.UpdateTick += Update;

            //foreach (var item in levels) {
            //    foreach (var go in item.objects) {
            //        go.hasToRedraw = true;
            //    }
            //}
            //for (int i = 0; i < levelCount; i++) {
            //    RedrawFull(i);
            //}
        }

        private void Update() {
            goldCounter += MainHandler.deltaTime;
            if (goldCounter >= 1f) {
                gold++;
                goldCounter -= 1f;
            }
            MainHandler.instance.goldLabel.Text = "Gold: " + gold;
        }
    }
}
