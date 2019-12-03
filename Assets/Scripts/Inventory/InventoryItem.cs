using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Usable,
    Dropable
}

public enum Item
{
    Shaverma,
    Book,
    Lab,
    EnergyDring
}

public class InventoryItem : MonoBehaviour {

    [SerializeField]
    protected int countItems;

    [SerializeField]
    public string itemName;

    [SerializeField]
    protected ItemTypes itemUsingType;

    [SerializeField]
    public Item itemType;

    public SpriteRenderer sprite;

    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    public int Count {
        get {
            return this.countItems;
        }
    }

    protected float speed = 10.0F;
    protected Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public void AddOneMore()
    {
        this.countItems++;
    }

    public void Action()
    {
        Debug.Log("USE");
        this.Use();
    }

    public virtual void Use()
    {
        countItems--;
    }

    public virtual void Drop()
    {
        countItems--;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.itemUsingType == ItemTypes.Dropable)
        {
            Unit unit = collider.GetComponent<Unit>();

            if (unit && unit.gameObject != parent)
            {
                Destroy(gameObject);
            }
        }
    }
}
