using UnityEngine;
using System;
using System.Collections;

public class SRManager : MonoBehaviour {

    SceneManager SM;
    UIManager UIMgr;
    SoundManager SMgr;
    public SpeechRecognizerDemoSceneManager SRSMgr;

    void Start()
    {
        UIMgr = GetComponent<UIManager>();
        SMgr = GetComponent<SoundManager>();
        SM = SceneManager.Instance;
    }

    public void StartWaiting4Word(Action<string> onWord, params string[] anyWord)
    {
        SRSMgr.StartSR((string r) =>
        {
            foreach (string w in anyWord)
            {
                if (r.Contains(w))
                {
                    onWord(w);
                    return;
                }
            }

            onWord("");
            return;
        });
    }
}
