using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private bool avaliable = true;
    private bool playerInTarget = false;

    public Transform target;

    public bool NearDoors
    {
        get
        {
            return this.playerInTarget;
        }
    }

    public bool IsAvaliable
    {
        get
        {
            if (!this.avaliable)
                Debug.Log("Locked music");

            return this.avaliable;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.playerInTarget = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.playerInTarget = false;
    }

    public void Activate(Transform otherTransform)
    {
        if (this.avaliable && this.playerInTarget)
        {
            otherTransform.position = target.position;
            Camera.main.transform.position = target.position;
        }
    }
}