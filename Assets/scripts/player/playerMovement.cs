using System.Collections;
using System.Collections.Generic;
using UnityEngine;

RequireComponent(typeof(Rigidbody2D), typeof(Animator))
public class playermovement : MonoBehaviour
{
     Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
