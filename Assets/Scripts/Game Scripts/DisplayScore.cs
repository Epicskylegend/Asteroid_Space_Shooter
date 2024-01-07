using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : Enemy
{

    public float currentScore = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnGUI() 
    {
        // Display Score
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24; 

        GUI.Label(new Rect(0, 0, 1000, 1000), "Score: " + currentScore.ToString(), style);

        GUI.Label(new Rect(1200, 0, 1000, 1000), "Time: " + Mathf.Round(Time.time), style);
    }



    public void increaseScore()
    {
      
        currentScore += Mathf.Round(5 * Time.time);
        Debug.Log(Time.time);
       
    }
}
