using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    [SerializeField]
    private List<InventoryItem> items = new List<InventoryItem>();

    [SerializeField]
    private GameObject player;

	private void Awake()
    {
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update () {
        if (Input.GetButton("LootBar Item 1")) this.InventoryItemUse(0);
        if (Input.GetButton("LootBar Item 2")) this.InventoryItemUse(1);
        if (Input.GetButton("LootBar Item 3")) this.InventoryItemUse(2);
        if (Input.GetButton("LootBar Item 4")) this.InventoryItemUse(3);
        if (Input.GetButton("LootBar Item 5")) this.InventoryItemUse(4);
        if (Input.GetButton("LootBar Item 6")) this.InventoryItemUse(5);
        if (Input.GetButton("LootBar Item 7")) this.InventoryItemUse(6);
        if (Input.GetButton("LootBar Item 8")) this.InventoryItemUse(7);
        if (Input.GetButton("LootBar Item 9")) this.InventoryItemUse(8);
    }

    private void InventoryItemUse(int index)
    {
        if (this.items.Count > index)
        {
            if (this.items[index] == null) return;
            this.items[index].Action();
        }
    }

    public void Add(InventoryItem item)
    {
        int index = 0;

        if (this.items.Count >= 1)
        {
            Debug.Log("начинаем поиск места");
            foreach (InventoryItem iitem in this.items)
            {
                Debug.Log(iitem.itemName + " == " + item.itemName);
                Debug.Log(iitem);
                if (iitem.itemName == item.itemName)
                {
                    Debug.Log("Добавляем 1");
                    iitem.AddOneMore();
                    break;
                }
                else
                {
                    if (iitem == null)
                    {
                        Debug.Log("Добавляем 2");
                        this.items.Insert(index, item);
                        this.DrawOnLootBox(index, item);
                        break;
                    }
                }
                index++;
            }
            Debug.Log("заканчиваем поиск места");
        } else {
            this.items.Insert(0, item);
            this.DrawOnLootBox(0, item);
            Debug.Log("Место не искали отрисовали так");
        }
    }

    private void DrawOnLootBox(int index, InventoryItem pickedItem)
    {
        Debug.Log("Drawing");
        Debug.Log("Place: " + index);

        GameObject other = GameObject.FindGameObjectsWithTag("InventoryItems")[index];
        if (other.GetComponent<SpriteRenderer>() == null) other.AddComponent<SpriteRenderer>();
        SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
        sprite.sprite = pickedItem.sprite.sprite;
        sprite.sortingOrder = 102;
        other.GetComponent<Renderer>().enabled = true;
    }
}
