using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float startTime = 60.0F;

    private float timerTime = 0;
    private bool timerStarted = false;
    private bool timerPaused = false;

    [SerializeField]
    public AbstractTimeProvider provider;

    public float TimerTime
    {
        get
        {
            return this.timerTime;
        }
    }

	private void Start ()
    {
		
	}

    public void StartTimer()
    {
        if (this.timerPaused)
        {
            this.timerPaused = false;
            this.provider.TimerUnPaused();
        }
        else
        {
            this.timerTime = this.startTime;
            timerStarted = true;
            this.provider.TimerStarted();
        }
    }

    public void StopTimer()
    {
        this.timerStarted = false;
        this.timerPaused = false;
        this.timerTime = 0;
        this.provider.TimerStoped();
    }

    public void PauseTimer()
    {
        this.timerPaused = true;
        this.provider.TimerPaused();
    }
	
	void Update ()
    {
        if(this.timerStarted && !this.timerPaused)
        {
            this.timerTime -= Time.deltaTime;

            if (this.timerTime <= 0.0f)
            {
                this.TimerEnded();
                this.timerStarted = false;
            }
        }
    }

    private void TimerEnded()
    {
        this.provider.TimerEnded();
    }
}
