using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    class DrawingSystem {

        public static DrawingSystem instance;


        //Dictionary<Panel, List<(GameObject, CustomPictureBox)>> imagesInLevel = new Dictionary<Panel, List<(GameObject, CustomPictureBox)>>();

        public DrawingSystem() {
            instance = this;
        }

        public void Redraw(int level) {
            DrawLevelToPanel(MainHandler.instance.GetLevelPanel(level), GameManager.instance.levels[level]);
        }

        public void RedrawFull(int level) {
            foreach (var item in GameManager.instance.levels[level].objects) {
                item.hasToRedraw = true;
            }
            DrawLevelToPanel(MainHandler.instance.GetLevelPanel(level), GameManager.instance.levels[level]);
        }

        private void DrawLevelToPanel(Panel panel, Level level) {
            //if (imagesInLevel.ContainsKey(panel) && !imagesInLevel[panel].Where(tupel => tupel.Item1.hasToRedraw).Any()) return;


            panel.BackColor = level.backgroundColor;


            //if (!imagesInLevel.ContainsKey(panel)) {
            //    //imagesInLevel.Add(panel, new List<(GameObject, CustomPictureBox)>());
            //    panel.SendToBack();
            //    panel.BackColor = level.backgroundColor;
            //} else {
            //    //for (int i = imagesInLevel[panel].Count - 1; i >= 0; i--) {
            //    //    var tupel = imagesInLevel[panel][i];
            //    //    if (tupel.Item1.hasToRedraw) {
            //    //        imagesInLevel[panel].Remove(tupel);
            //    //        tupel.Item2.Dispose();
            //    //    } else {
            //    //        tupel.Item2.BringToFront();
            //    //    }
            //    //}
            //}

            foreach (GameObject gameObject in level.objects) {
                if (!gameObject.hasToRedraw) continue;
                gameObject.hasToRedraw = false;

                CustomPictureBox pb = gameObject.pictureBox;
                pb.Size = gameObject.GetSizeFromWidth();
                //Console.WriteLine(pb.Size + "," + gameObject.position);
                //pb.Top = panel.Top + (int)(panel.Height) /* *(1f - gameObject.position.y)) - pb.Height*/;
                //pb.Top = panel.Top - pb.Height;
                pb.Top = (int)((panel.Height - pb.Height) * (1f - gameObject.position.y));
                pb.Left = (int)(gameObject.position.x * MainHandler.windowSize.Width);
                //Console.WriteLine(pb.Location);
                //pb.Image = gameObject.pictureBox.Image;
                //pb.BackColor = Color.FromArgb(255, 255, 120, 150);
                //pb.BackColor = Color.Transparent;
                pb.BorderStyle = BorderStyle.FixedSingle;   //#DEBUG
                pb.overlay.BorderStyle = BorderStyle.FixedSingle;   //#DEBUG
                if (!panel.Controls.Contains(pb)) panel.Controls.Add(pb);
                //imagesInLevel[panel].Add((gameObject, pb));
                pb.BringToFront();
            }
        }
    }
}
