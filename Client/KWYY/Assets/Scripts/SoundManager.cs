using UnityEngine;
using System;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip Ask4Help;
    public AudioClip MakeSureWord;

    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlayAsk4Help(Action onEnd)
    {
        AS.clip = Ask4Help;
        AS.Play();
        StartCoroutine(DelayCall(3, onEnd));
    }

    IEnumerator DelayCall(float t, Action call)
    {
        yield return new WaitForSeconds(t);
        if (call != null)
            call();
    }
}
