using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool facingRight = true;

    

    public int score = 0;
    public int health = 5;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
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

        if(moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if(moveInput < 0 && facingRight)
        {
            Flip();
        }





}

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "powerup speed")
        {
            speed = 4f;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetPower());
       }


        if (collision.tag == "powerup jump")
        {
            jumpForce = 4f;
            GetComponent<SpriteRenderer>().color = Color.blue;
            StartCoroutine(ResetPower());
       }
        
       

    }


    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(5);
        speed = 2f;
        jumpForce = 3f;
        GetComponent<SpriteRenderer>().color = Color.white;

    }



    public void TakeDamage(int turretdamage)
    {
        health -= turretdamage;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    
    }



}
























