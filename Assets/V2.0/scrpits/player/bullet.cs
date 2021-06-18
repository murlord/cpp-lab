using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifetime;
    public int damage;

    void Start()
    {
        rb.velocity = transform.right * speed;

        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        turretScript enemy = collision.GetComponent<turretScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);

        }
        if (collision.tag == "MeleeEnemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

    

   
