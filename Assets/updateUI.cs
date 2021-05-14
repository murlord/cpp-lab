using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateUI : MonoBehaviour
{
 private enum CollectibleType
    {
        UIText = GetComponent<TextMeshProUGUI>();
        CollectibleType = ObjectPrefab.GetComponent<Collectables>().ID;

    }

    private TextMeshProUGUI UIText;


    

    
}
