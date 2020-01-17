using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    class Behavior {

        public GameObject gameObject;

        public Behavior(GameObject gameObject) {
            this.gameObject = gameObject ?? throw new ArgumentNullException(nameof(gameObject));
            gameObject.behaviors.Add(this);
        }
    }
}
