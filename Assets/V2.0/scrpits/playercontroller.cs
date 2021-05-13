using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;
    

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    private Animator anim;



    void Start()
{
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

}

void FixedUpdate()
{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);



        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }






}






    void Update()
    {

        


        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }



        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }



        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }





    }




   













}
























