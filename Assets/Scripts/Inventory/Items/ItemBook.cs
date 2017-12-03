using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBook : InventoryItem
{
    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }

    public override void Use()
    {
        Debug.Log("Читаем");
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.Intelligence += 1;

        if (countItems >= 2)
        {
            //текст изменяем на кол-во
        }
        else
        {
            //Destroy(gameObject);
        }
    }
}
