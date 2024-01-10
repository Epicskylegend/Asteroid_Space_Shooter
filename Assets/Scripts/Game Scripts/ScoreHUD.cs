using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHUD : MonoBehaviour
{
    private Stats stats;

    public float currentScore = 0;
    
    
    public TMP_Text scoreText;
  

    void Start()
    {
      
      
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + currentScore);
     
    } 
   
/*
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;

        GUI.Label(new Rect(0, 0, 1000, 1000), "<color=cyan>Score: </color> " + currentScore.ToString(), style);

        GUI.Label(new Rect(1250, 0, 1000, 1000), "Time: " + Mathf.Round(Time.time), style);

        GUI.Label(new Rect(650, 0, 1000, 1000), "<color=green>Health:</color> " + stats.health.ToString(), style);*/
    



    public void increaseScore(float deathScore)
    {

        currentScore += deathScore;
       
    }
}
