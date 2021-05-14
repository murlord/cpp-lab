using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifetime;
    
    void Start()
    {
        rb.velocity = transform.right * speed;

        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        Destroy(gameObject, lifetime);

        

    }

    
}
