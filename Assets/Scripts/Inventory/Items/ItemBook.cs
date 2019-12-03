using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBook : InventoryItem
{
    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.itemUsingType = ItemTypes.Usable;
    }

    public override void Use()
    {
        Debug.Log("Читаем");
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.Intelligence += 1;

        base.Use();
    }
}
