using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{


    public float deathScore = 0;
    public TMP_Text incrementScoreText;

    private void Start()
    {
       
        Destroy(gameObject, 0.5f);
       
    }
       

    void Update()
    {
       
        
        incrementScoreText.SetText("+ " + deathScore);

    }
     

    }

