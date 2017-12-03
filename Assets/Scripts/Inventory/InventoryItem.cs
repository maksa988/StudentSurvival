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
    Shaverma
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

    private float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public void AddOneMore()
    {

    }

    public void Action()
    {
        if (this.itemUsingType == ItemTypes.Dropable) this.Drop();
        if (this.itemUsingType == ItemTypes.Usable) this.Use();
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
