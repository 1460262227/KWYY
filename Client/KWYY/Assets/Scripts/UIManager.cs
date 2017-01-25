﻿using UnityEngine;
using System;

public class UIManager : MonoBehaviour {

    public GameObject Wait4ClickAnyMask;

    Func<bool> onEndWaiter = null;
    public void Wait4ClickAny(Func<bool> onEnd)
    {
        Wait4ClickAnyMask.SetActive(true);
        onEndWaiter = onEnd;
    }

    public void OnClickAny()
    {
        if (onEndWaiter != null)
        {
            bool closeMask = onEndWaiter();
            Wait4ClickAnyMask.SetActive(closeMask);
        }
        else
            Wait4ClickAnyMask.SetActive(false);

        onEndWaiter = null;
    }
}