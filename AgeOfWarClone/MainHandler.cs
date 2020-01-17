using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace AgeOfWarClone {
    public partial class MainHandler : Form {

        public static MainHandler instance;

        private Panel[] levelPanels = new Panel[GameManager.levelCount];
        public Panel uiPanel;

        public static Size windowSize;
        public static Size panelSize;

        private static DateTime lastFrame;
        public static float deltaTime = 0f;

        public delegate void InputOccured(Keys key);
        public InputOccured InputEventDown;
        public InputOccured InputEventUp;

        public delegate void GameTick();
        public GameTick UpdateTick;

        private Thread mainloop;
        private static void MainLoop() {
            lastFrame = DateTime.Now;
            while (true) {
                //Console.WriteLine("I am working");
                deltaTime = (float)(DateTime.Now.Subtract(lastFrame).TotalMilliseconds / 1000f);
                lastFrame = DateTime.Now;

                instance.Tick();
                Thread.Sleep(20);
            }
        }

        public MainHandler() {
            instance = this;
            InitializeComponent();

            uiPanel = new Panel();
            uiPanel.BorderStyle = BorderStyle.FixedSingle;
            uiPanel.Height = 40;
            uiPanel.Name = "UI";
            Controls.Add(uiPanel);

            GenerateUI();

            for (int i = 0; i < GameManager.levelCount; i++) {
                levelPanels[i] = new Panel();

                levelPanels[i].BorderStyle = BorderStyle.FixedSingle;
                levelPanels[i].Location = new Point(50 * i, 50 * i);
                levelPanels[i].Name = "Level " + i;
                levelPanels[i].Size = new Size(35, 35);

                Controls.Add(levelPanels[i]);
            }

            //MainHandler_ResizeEnd(null, null);

            new DrawingSystem();
            new Physics();
            new GameManager();
            new PlayerMove(playerImage);

            mainloop = new Thread(new ThreadStart(MainLoop));
            mainloop.Start();
        }

        public Label goldLabel;
        private void GenerateUI() {
            Button button = new Button();
            uiPanel.Controls.Add(button);
            button.Text = "123";
            button.Anchor = AnchorStyles.Left;
            button.Left = 5;
            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                Console.WriteLine(123);
            });

            button = new Button();
            uiPanel.Controls.Add(button);
            button.Text = "345";
            button.Anchor = AnchorStyles.Left;
            button.Left = 100;
            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                Console.WriteLine(345);
            });

            goldLabel = new Label();
            uiPanel.Controls.Add(goldLabel);
            goldLabel.Text = "Gold: 0";
            goldLabel.Anchor = AnchorStyles.Right;
            goldLabel.Font = new Font(goldLabel.Font.FontFamily, 25f, FontStyle.Bold);
            goldLabel.TextAlign = ContentAlignment.MiddleRight;
            goldLabel.AutoSize = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
            KeyPreview = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            mainloop.Abort();
        }

        private void KeyPressed(object sender, KeyEventArgs e) {
            InputEventDown?.Invoke(e.KeyCode);
            
        }

        private void KeyReleased(object sender, KeyEventArgs e) {
            InputEventUp?.Invoke(e.KeyCode);
            
        }

        public void Tick() {
            if (InvokeRequired) {
                Invoke(new MethodInvoker(delegate { Tick(); }));
            } else {
                UpdateTick.Invoke();
            }
            
        }

        public Panel GetLevelPanel(int level) {
            return levelPanels[level];
        }

        private float playerSize = 0.08f;
        private void ResizeGame(object sender, EventArgs e) {
            try {
                Size size = ActiveForm.Size;

                uiPanel.Width = size.Width;

                size.Height -= 72;
                //playerImage.Size = new Size((int)(size.Height * playerSize), (int)(size.Height * playerSize));
                windowSize = size;
                size.Height /= GameManager.levelCount;
                panelSize = size;
                for (int i = 0; i < GameManager.levelCount; i++) {
                    levelPanels[i].Size = size;
                    levelPanels[i].Location = new Point(0, size.Height * i + 40);
                    DrawingSystem.instance.RedrawFull(i);
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}
