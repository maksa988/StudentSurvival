using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLab : InventoryItem
{
    private bool shooting = false;
    

    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.itemUsingType = ItemTypes.Dropable;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + this.direction, this.speed * Time.deltaTime);
    }

    public override void Drop()
    {
        Debug.Log("Кидаем");
        
        this.Parent = GameObject.FindGameObjectWithTag("Player");
        this.Direction = this.transform.right * (sprite.flipX ? -1.0F : 1.0F);

        base.Use();
    }
}
