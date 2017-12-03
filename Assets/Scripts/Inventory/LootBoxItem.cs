using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxItem : MonoBehaviour {

    private Item type;

    private InventoryController controller;
    private InventoryItem item;

    private bool playerInTarget;

    private void Awake()
    {
        this.controller = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryController>();
        this.item = gameObject.GetComponent<InventoryItem>();
    }

    private void Update()
    {
        if (Input.GetButton("Action") && this.playerInTarget) this.Pick();
    }

    private void Pick()
    {
        Debug.Log(this.item.itemType);
        this.controller.Add(this.item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        this.playerInTarget = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.playerInTarget = false;
    }

}
