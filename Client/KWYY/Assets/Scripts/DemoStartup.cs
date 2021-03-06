﻿using UnityEngine;

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
        SRManager SRMgr;
        private void Start()
        {
            UIMgr = GetComponent<UIManager>();
            SMgr = GetComponent<SoundManager>();
            SRMgr = GetComponent<SRManager>();

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
            SMgr.PlayAsk4Help(() => 
            {
                StartSR(1);
            });
        }

        void StartSR(int n)
        {
            UIMgr.SetText(" *** " + n);
            SRMgr.StartWaiting4Word((string r) =>
            {
                UIMgr.SetText(r);
                if (r.ToLower() == "马路。")
                {
                    SM.Switch2Scene("Road");
                    UIMgr.SetText("*");
                }
                else if (r.ToLower() == "水果店。")
                {
                    SM.Switch2Scene("FruitStore");
                    UIMgr.SetText("*");
                }
                else if (r.ToLower() == "城堡。")
                {
                    SM.Switch2Scene("LittleHouse");
                    UIMgr.SetText("*");
                }
                else
                    StartSR(n + 1);
            }, "马路。", "水果店。", "城堡。");
        }
    }
}
