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
        UIManager UIMgr;
        SoundManager SMgr;
        private void Start()
        {
            UIMgr = GetComponent<UIManager>();
            SMgr = GetComponent<SoundManager>();

            SM = SceneManager.Instance;
            SM.Scenes["Bedroom"] = Bedroom;
            SM.Scenes["Road"] = Road;
            SM.Scenes["FruitStore"] = FruitStore;
            SM.Scenes["LittleHouse"] = LittleHouse;

            SM.Switch2Scene("Bedroom");

            UIMgr.Wait4ClickAny(() => { (Bedroom as BedroomScene).PlaySceneAni(PlayAsk4Help);  return false; });
        }

        void PlayAsk4Help()
        {
            SMgr.PlayAsk4Help(() => {  });
        }
    }
}
