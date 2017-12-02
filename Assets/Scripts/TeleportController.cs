using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectState
{
    Close,
    Open
}

public class TeleportController {

    [SerializeField]
    private float openedTime = 2F;

    private float currentOpenedTime = 0;
    private bool openTimer = false;

    [SerializeField]
    private GameObject enterObject;
    [SerializeField]
    private GameObject exitObject;

    private ObjectState State
    {
        get
        {
            return (ObjectState) enterObject.GetComponent<Animator>().GetInteger("State");
        }
        set
        {
            enterObject.GetComponent<Animator>().SetInteger("State", (int) value);
            exitObject.GetComponent<Animator>().SetInteger("State", (int) value);
        }
    }

    public TeleportController(float waitingTime, GameObject enterObject, GameObject exitObject)
    {
        this.openedTime = waitingTime;
        this.enterObject = enterObject;
        this.exitObject = exitObject;
    }

    public void Update()
    {
        if(this.openTimer)
        {
            this.currentOpenedTime -= Time.deltaTime;
            if (this.currentOpenedTime <= 0.0f)
            {
                this.openTimer = false;
                this.currentOpenedTime = this.openedTime;
                this.Close();
            }
        }
    }

    public void Open()
    {
        this.openTimer = true;
        this.currentOpenedTime = this.openedTime;

        this.State = ObjectState.Open;
    }

    public void Close()
    {
        this.State = ObjectState.Close;
    }
}
