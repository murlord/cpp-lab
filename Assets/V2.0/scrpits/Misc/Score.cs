using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static Score instance;
    public TextMeshProUGUI text;
    int score;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeScore(int collectableValue)
    {
        score += collectableValue;
        text.text = "X" + score.ToString();
    }
}
