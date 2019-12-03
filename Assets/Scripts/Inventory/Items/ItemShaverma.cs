using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShaverma : InventoryItem {
    
    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.itemUsingType = ItemTypes.Usable;
    }

	public override void Use()
    {
        Debug.Log("Хаваем");
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.Sleep += 1;

        base.Use();
    }
}
