using System;
using System.Collections;
using UnityEngine;

public class BedroomScene : Scene
{
    public CharContoller Npc;
    public CharContoller Me;
    public Transform Me2Pos;

    public void PlaySceneAni(Action onEnd)
    {
        StartCoroutine(PlayAni1(onEnd));
    }

    IEnumerator PlayAni1(Action onEnd)
    {
        yield return MeWalk2Npc();
        yield return NpcTurnBack();
        if (onEnd != null)
            onEnd();
    }

    IEnumerator MeWalk2Npc()
    {
        Me.Play("xingzou");

        Vector3 pFrom = Me.transform.position;
        Vector3 pTo = Me2Pos.position;
        float cnt = 75;
        for (int i = 0; i < cnt + 1; i++)
        {
            Vector3 p = (pTo - pFrom) * i / cnt + pFrom;
            Me.transform.localPosition = p;
            yield return null;
        }

        Me.Play("daiji01");
    }

    IEnumerator NpcTurnBack()
    {
        Quaternion rFrom = Npc.transform.rotation;
        Quaternion rTo = new Quaternion();
        rTo.SetLookRotation(Me.transform.position - Npc.transform.position);
        float cnt = 25;
        for (int i = 0; i < cnt + 1; i++)
        {
            Quaternion r = Quaternion.Slerp(rFrom, rTo, i / cnt);
            Npc.transform.localRotation = r;
            yield return null;
        }
    }
}