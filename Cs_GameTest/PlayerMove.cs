using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfWarClone {
    class PlayerMove {
        public MovingObject Player { get; private set; }
        private Vector2 movementDirection = new Vector2();

        private float speed = 0.3f;

        private int currentPlayerLevel = 0;

        private float playerSize = 0.04f;
        public PlayerMove(PictureBox player) {
            Player = new MovingObject(player, playerSize);
            Player.pictureBox.BorderStyle = BorderStyle.FixedSingle;
            Player.pictureBox.overlay.BorderStyle = BorderStyle.FixedSingle;

            MainHandler.instance.InputEventDown += KeyDown;
            MainHandler.instance.InputEventUp += KeyUp;
            MainHandler.instance.UpdateTick += Update;

            Player.AddComponent<Collider>().SetColliderValues(level: currentPlayerLevel);
            Player.GetComponent<Collider>().onCollisionAction = (obj)=>{ Player.pictureBox.SetTint(Color.FromArgb(75, Color.Blue)); };
            Player.GetComponent<Collider>().exitCollisionAction = (obj) => { Player.pictureBox.SetTint(Color.Transparent); };
            SetPlayerToLevel();
            Player.position.x = 0.2f;
        }

        private void KeyDown(Keys key) {
            switch (key) {
                case Keys.A:
                    movementDirection.x = -1f;
                    break;
                case Keys.D:
                    movementDirection.x = +1f;
                    break;
                case Keys.W:
                    currentPlayerLevel--;
                    if (currentPlayerLevel < 0) currentPlayerLevel = 0;
                    SetPlayerToLevel();
                    break;
                case Keys.S:
                    currentPlayerLevel++;
                    if (currentPlayerLevel >= GameManager.levelCount) currentPlayerLevel = GameManager.levelCount - 1;
                    SetPlayerToLevel();
                    break;
                default:
                    break;
            }
        }

        private void KeyUp(Keys key) {
            switch (key) {
                case Keys.A:
                    if (movementDirection.x < 0f)
                        movementDirection.x = 0f;
                    break;
                case Keys.D:
                    if (movementDirection.x > 0f)
                        movementDirection.x = 0f; break;
                default:
                    break;
            }
        }

        private void Update() {
            if (!movementDirection.Equals(Vector2.zero)) {
                Player.Move(Vector2.right * movementDirection.x * speed * MainHandler.deltaTime);
            }
        }

        private void SetPlayerToLevel() {
            Player.pictureBox.Parent?.Controls.Remove(Player.pictureBox);
            Panel temp = MainHandler.instance.GetLevelPanel(currentPlayerLevel);
            temp.Controls.Add(Player.pictureBox);
            Player.pictureBox.Top = temp.Height - Player.pictureBox.Height;
            Player.pictureBox.BringToFront();
            Player.Move(Vector2.zero);

            Player.GetComponent<Collider>().level = currentPlayerLevel;
        }
    }
}
