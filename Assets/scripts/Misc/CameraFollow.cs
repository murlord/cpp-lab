using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    if (player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;
        cameraTransform.x = player.transform.position.x - 0.5f;
        //cameraTransform.x = Mathf.Clamp(cameraTransform.x, );
            transform.position = cameraTransform;
        }
    }
}
