using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfWarClone {
    //struct ColliderData {
    //    public float width;
    //    public float height;
    //    public byte layer;
    //    public int level;
    //    public Action<GameObject> onCollisionAction;
    //    public Action<GameObject> exitCollisionAction;

    //    public ColliderData(float width, float height, byte layer, int level, Action<GameObject> onCollisionAction, Action<GameObject> exitCollisionAction) {
    //        this.width = width;
    //        this.height = height;
    //        this.layer = layer;
    //        this.level = level;
    //        this.onCollisionAction = onCollisionAction ?? throw new ArgumentNullException(nameof(onCollisionAction));
    //        this.exitCollisionAction = exitCollisionAction ?? throw new ArgumentNullException(nameof(exitCollisionAction));
    //    }
    //}

    class Physics {

        private static List<Collider> registeredColliders;
        private static Dictionary<Collider, List<Collider>> alreadyCollidedDudes;
        private static readonly Dictionary<byte, byte[]> layerCollisionTable = new Dictionary<byte, byte[]>() {
            {0, new byte[]{ 0,1,2 } },
            {1, new byte[]{ 2 } }
        };

        public Physics() {
            MainHandler.instance.UpdateTick += Update;
            registeredColliders = new List<Collider>();
            alreadyCollidedDudes = new Dictionary<Collider, List<Collider>>();
        }

        private void Update() {
            if (registeredColliders.Count > 1) {
                for (int subject = 0; subject < registeredColliders.Count; subject++) {
                    for (int @object = subject + 1; @object < registeredColliders.Count; @object++) {
                        Collider subj = registeredColliders[subject];
                        Collider obj = registeredColliders[@object];
                        if (subj.level == obj.level && layerCollisionTable[subj.layer].Contains(obj.layer)) {
                            //Console.WriteLine($"comparing {subj.position.x} to {obj.position.x} with dist {(subj.collider.width + obj.collider.width) / 2f}");
                            if (Math.Abs(subj.gameObject.position.x - obj.gameObject.position.x) < (subj.width + obj.width) / 2f) {

                                if (!CheckAlreadyCollided(subj, obj)) {
                                    subj.onCollisionAction?.Invoke(obj);
                                    obj.onCollisionAction?.Invoke(subj);
                                    if (alreadyCollidedDudes.ContainsKey(subj)) {
                                        alreadyCollidedDudes[subj].Add(obj);
                                    } else {
                                        alreadyCollidedDudes.Add(subj, new List<Collider>() { obj });
                                    }
                                    //Console.WriteLine($"Collision at level{subj.collider.level} position {subj.position.x}");
                                }


                            } else if(CheckAlreadyCollided(subj, obj)) {
                                alreadyCollidedDudes[subj].Remove(obj);
                                subj.exitCollisionAction?.Invoke(obj);
                                obj.exitCollisionAction?.Invoke(subj);
                                //Console.WriteLine($"ExitCollision at level{subj.collider.level} position {subj.position.x}");
                            }
                        } else if (CheckAlreadyCollided(subj, obj)) {
                            alreadyCollidedDudes[subj].Remove(obj);
                            subj.exitCollisionAction?.Invoke(obj);
                            obj.exitCollisionAction?.Invoke(subj);
                            //Console.WriteLine($"ExitCollision at level{subj.collider.level} position {subj.position.x}");
                        }
                    }
                }
            }
            
        }

        private static bool CheckAlreadyCollided(Collider subj, Collider obj) {
            if (alreadyCollidedDudes.ContainsKey(subj)) {
                return alreadyCollidedDudes[subj].Contains(obj);
            }
            return false;
        }

        public static void RegisterObject(Collider col) {
            try {
                registeredColliders.Add(col);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
