using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeLoaderTimer : AbstractTimeProvider
{
    private Image fadeLoader;
    private float opacity = 1;

    public override void Awake()
    {
        Debug.Log("FADE LOADER");
        this.fadeLoader = GameObject.FindGameObjectWithTag("FadeLoader").GetComponent<Image>();
    }

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
        Fade();
        Debug.Log("TimerUpdated");
    }

    private void Fade()
    {
        opacity -= 0.1F;
        fadeLoader.color = new Color(fadeLoader.color.a, fadeLoader.color.g, fadeLoader.color.b, opacity);
    }
}
