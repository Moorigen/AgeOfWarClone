using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {

    enum Team {
        Own, Enemy, Neutral
    }

    class MilitaryUnit : Behavior {

        public enum MilitaryUnitType {
            Melee, Ranged
        }

        private MilitaryUnitType unitType;
        private int health = 3;
        private int damage = 1;
        private float timeBetweenAttacks = 1f;
        
        public MilitaryUnit(GameObject gameObject, MilitaryUnitType unitType) : base(gameObject) {
            this.unitType = unitType;
        }
    }
}
