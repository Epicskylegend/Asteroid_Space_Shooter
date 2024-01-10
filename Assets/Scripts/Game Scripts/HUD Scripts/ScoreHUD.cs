using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHUD : MonoBehaviour
{
    public float currentScore = 0;
    
    
    public TMP_Text scoreText;
  
    void Update()
    {
        scoreText.SetText("Score: " + currentScore);
     
    } 
   
    public void increaseScore(float deathScore)
    {

        currentScore += deathScore;
       
    }
}
