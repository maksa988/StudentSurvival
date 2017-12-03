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
        this.Parent.GetComponent<Character>().Sleep += 1;

        if(countItems >= 2)
        {
            //текст изменяем на кол-во
        } else
        {
            Destroy(gameObject);
        }
    }
}
