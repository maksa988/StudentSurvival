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
            this.items[0].Action();
            HideItem(0);
        }
        if (Input.GetButton("LootBar Item 2"))
        {
            this.items[1].Action();
            HideItem(1);
        }
        if (Input.GetButton("LootBar Item 3"))
        {
            this.items[2].Action();
            HideItem(2);
        }
        if (Input.GetButton("LootBar Item 4"))
        {
            this.items[3].Action();
            HideItem(3);
        }
        if (Input.GetButton("LootBar Item 5"))
        {
            this.items[4].Action();
            HideItem(4);
        }
    }

    private void InventoryItemUse(int index)
    {
        Debug.Log("Нажали кнопочку" + index);
        Debug.Log("Count k: " + this.items.Count);
        Debug.Log(this.items.Count > index);
        Debug.Log(this.items[1]);
        if (this.items.Count > index)
        {
            Debug.Log("index" + index);
            Debug.Log(this.items[index]);
            if (this.items[index] == null) return;
            this.items[index].Action();
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
        GameObject other = GameObject.FindGameObjectsWithTag("InventoryItems")[8 - index];other.GetComponent<Renderer>().enabled = true;
        other.GetComponent<Renderer>().enabled = false;
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
