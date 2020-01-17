using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    class Collider : Behavior {

        public float width;
        public float height;
        public byte layer;
        public int level;
        public Action<Collider> onCollisionAction;
        public Action<Collider> exitCollisionAction;

        public Collider(GameObject gameObject) : base(gameObject) {
            Physics.RegisterObject(this);
            //width = gameObject.size.x;
            //height = gameObject.size.y;
            width = gameObject.width;
        }

        public void SetColliderValues(float width, float height, byte layer, int level, Action<Collider> onCollisionAction, Action<Collider> exitCollisionAction) {
            this.width = width;
            this.height = height;
            this.layer = layer;
            this.level = level;
            this.onCollisionAction = onCollisionAction ?? throw new Exception();
            this.exitCollisionAction = exitCollisionAction ?? throw new Exception();
        }

        public void SetColliderValues(float width = float.NaN, float height = float.NaN, byte layer = 255, int level = -1) {
            this.width = float.IsNaN(width) ? this.width : width;
            this.height = float.IsNaN(height) ? this.height : height;
            this.layer = layer == 255 ? this.layer : layer;
            this.level = level == -1 ? this.level : level;
        }
    }
}
