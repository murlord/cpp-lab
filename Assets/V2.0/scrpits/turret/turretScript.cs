using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour
{
    public float Range;

    public Transform Target;

    bool Deteccted = false;

    Vector2 Direction;
    public GameObject Bullet;
    public float FireRate;
    float shootingCD = 0;

    public Transform ShootPoint;
    public float Force;

    public int health = 100;
    public GameObject deathEffect;



    public AudioSource turretExp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "player")
            {
                if (Deteccted == false)
                {
                    Deteccted = true;
                }
            }
            else
            {
                if (Deteccted == true)
                {
                    Deteccted = false;
                }
            }
        }
        if (Deteccted)
        {
            if (Time.time > shootingCD)
            {
                shootingCD = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
       GameObject BulletIns =  Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        turretExp.Play();
    }
}
