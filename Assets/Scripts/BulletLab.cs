using UnityEngine;
using System.Collections;

public class BulletLab : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    private float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public Color Color
    {
        set { sprite.color = value; }
    }

    private SpriteRenderer sprite;

    private void Awake()
    {
        GameObject gObject = this.transform.GetChild(0).gameObject;
        gObject.SetActive(true);
        sprite = gObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = GameObject.FindGameObjectWithTag("Prepod").GetComponent<Prepod>();

        if (collider.tag == "Prepod")
        {
            Destroy(gameObject);
            unit.ReceiveDamage();
        }
    }
}
