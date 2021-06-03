using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Health : MonoBehaviour
{
    private SceneTransitions sceneTransitions;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        sceneTransitions = FindObjectOfType<SceneTransitions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            sceneTransitions.LoadScene("Dead");
                


        }
    }
}
