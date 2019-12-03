using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    [SerializeField]
    private List<InventoryItem> items = new List<InventoryItem>(9);

    [SerializeField]
    private GameObject player;

	private void Awake()
    {
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (Input.GetButton("LootBar Item 1"))
        {
            this.InventoryItemUse(0);
        }
        if (Input.GetButton("LootBar Item 2"))
        {
            this.InventoryItemUse(1);
        }
        if (Input.GetButton("LootBar Item 3"))
        {
            this.InventoryItemUse(2);
        }
        if (Input.GetButton("LootBar Item 4"))
        {
            this.InventoryItemUse(3);
        }
        if (Input.GetButton("LootBar Item 5"))
        {
            this.InventoryItemUse(4);
        }
    }

    private void InventoryItemUse(int index)
    {
        if (this.items.Count > index)
        {
            //Debug.Log("index: " + index);
            //Debug.Log("null: " + (this.items[index] == null));
            //Debug.Log("count: " + this.items[index].Count);

            if (this.items[index] != null)
            {
                this.items[index].Action();
                this.HideItem(index);
                return;
            } else
            {
                this.HideItem(index);
                return;
            }

            if (this.items[index].Count <= 0)
            {
                this.HideItem(index);
                return;
            }
        }
    }

    public void Add(InventoryItem item)
    {
        int index = 0;

        if (this.items.Count >= 1)
        {
            foreach (InventoryItem iitem in this.items)
            {
                if (iitem.itemName == item.itemName)
                {
                    iitem.AddOneMore();
                    break;
                } else
                {
                    if (iitem == null)
                    {
                        this.items.Insert(index, item);
                        this.DrawOnLootBox(index, item);
                        break;
                    }
                }
                index++;
            }

            if(index == this.items.Count && index != 9)
            {
                this.items.Insert(index, item);
                this.DrawOnLootBox(index, item);
            }
            
        } else {
            this.items.Insert(0, item);
            this.DrawOnLootBox(0, item);
        }
    }

    private void HideItem(int index)
    {
        GameObject other = GameObject.FindGameObjectsWithTag("InventoryItems")[8 - index];
        if(other.GetComponent<Renderer>() != null)
        {
            other.GetComponent<Renderer>().enabled = true;
            other.GetComponent<Renderer>().enabled = false;

            Destroy(other.GetComponent<Renderer>());
        }
    }

    private void DrawOnLootBox(int index, InventoryItem pickedItem)
    {
        GameObject other = GameObject.FindGameObjectsWithTag("InventoryItems")[8 - index];
        if (other.GetComponent<SpriteRenderer>() == null) other.AddComponent<SpriteRenderer>();
        SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
        sprite.sprite = pickedItem.sprite.sprite;
        sprite.sortingOrder = 102;
        other.GetComponent<Renderer>().enabled = true;
    }
}
