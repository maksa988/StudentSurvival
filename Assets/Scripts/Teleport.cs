using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private float waitingTime = 2F;
    private float curentWTime = 0F;

    [SerializeField]
    private bool avaliable = true;
    private bool playerInTarget = false;
    private bool waitToTeleport = false;

    [SerializeField]
    private GameObject enterObject;
    [SerializeField]
    private GameObject exitObject;

    [SerializeField]
    private TeleportController controller;

    public Transform target;
    private Transform player;

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
                GameObject.FindGameObjectWithTag("DoorLockedAudio").GetComponent<AudioController>().Play();

            return this.avaliable;
        }
    }

    private void Awake()
    {
        this.controller = new TeleportController(this.waitingTime, this.enterObject, this.exitObject);
    }

    private void Update()
    {
        if(this.waitToTeleport)
        {
            this.curentWTime -= Time.deltaTime;
            if (this.curentWTime <= 0.0f)
            {
                this.waitToTeleport = false;
                this.curentWTime = this.waitingTime;
                this.Transport();
            }
        }

        this.controller.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.playerInTarget = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.playerInTarget = false;
    }

    public void Activate(Transform player)
    {
        if (this.avaliable && this.playerInTarget)
        {
            this.controller.Open();
            this.player = player;
            this.curentWTime = this.waitingTime;
            this.waitToTeleport = true;
        }
    }

    private void Transport()
    {
        this.player.position = target.position;
    }
}