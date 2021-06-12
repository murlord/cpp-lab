using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject bulletPrefab;

    Animator anim;
    public AudioSource attackSound;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isShooting", true);
                Shoot();

                attackSound.Play();
            }
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation); 
    
    }

    void ResetFire()
    {
        anim.SetBool("isShooting", false);
    }


}
