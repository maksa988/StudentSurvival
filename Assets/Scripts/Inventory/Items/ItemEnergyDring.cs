using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnergyDring : InventoryItem
{

    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.itemUsingType = ItemTypes.Usable;
    }

    public override void Use()
    {
        Debug.Log("Пьем");
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.Sleep += 1;
        player.speed += 1F;

        base.Use();
    }
}
