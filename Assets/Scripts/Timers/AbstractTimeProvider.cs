using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTimeProvider : MonoBehaviour {

    public abstract void Awake();
    public abstract void TimerEnded();
    public abstract void TimerStarted();
    public abstract void TimerStoped();
    public abstract void TimerPaused();
    public abstract void TimerUnPaused();
    public abstract void TimerUpdated();
}
