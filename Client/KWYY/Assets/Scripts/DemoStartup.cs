using UnityEngine;

namespace Assets.Scripts
{
    public class DemoStartup : MonoBehaviour
    {
        public Scene Bedroom;
        public Scene Road;
        public Scene FruitStore;
        public Scene LittleHouse;

        SceneManager SM;
        private void Start()
        {
            SM = SceneManager.Instance;
            SM.Scenes["Bedroom"] = Bedroom;
            SM.Scenes["Road"] = Road;
            SM.Scenes["FruitStore"] = FruitStore;
            SM.Scenes["LittleHouse"] = LittleHouse;

            SM.Switch2Scene("Bedroom");
        }
    }
}
