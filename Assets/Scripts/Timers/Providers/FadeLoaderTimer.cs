using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLoaderTimer : AbstractTimeProvider
{
    public override void TimerEnded()
    {
        Debug.Log("TimerEnded");
    }

    public override void TimerPaused()
    {
        Debug.Log("TimerPaused");
    }

    public override void TimerStarted()
    {
        Debug.Log("TimerStarted");
    }

    public override void TimerUnPaused()
    {
        Debug.Log("TimerUnPaused");
    }

    public override void TimerStoped()
    {
        Debug.Log("TimerStoped");
    }

    public override void TimerUpdated()
    {
        Debug.Log("TimerUpdated");
    }
}
