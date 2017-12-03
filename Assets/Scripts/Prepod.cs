using UnityEngine;
using System.Collections;

public class Prepod : Monster
{
    [SerializeField]
    private float rate = 2.0F;
    [SerializeField]
    private Color bulletColor = Color.white;

    private BulletOcenka bullet;

    protected override void Awake()
    {
        bullet = Resources.Load<BulletOcenka>("BulletOcenka");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.5F;
        BulletOcenka newBullet = Instantiate(bullet, position, bullet.transform.rotation) as BulletOcenka;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = bulletColor;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {

        Unit unit = GameObject.FindGameObjectWithTag("Prepod").GetComponent<Prepod>();

        if (collider.tag == "BulletLab")
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}

