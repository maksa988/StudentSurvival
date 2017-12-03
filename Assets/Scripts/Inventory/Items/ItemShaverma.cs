using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShaverma : InventoryItem {
    
    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }

	public override void Use()
    {
        Debug.Log("Хаваем");
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.Sleep += 1;

        if (countItems >= 2)
        {
            //текст изменяем на кол-во
        } else
        {
            //Destroy(gameObject);
        }
    }
}
