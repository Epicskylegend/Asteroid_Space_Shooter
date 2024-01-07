using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private Stats stats;

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
        
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24; 

        GUI.Label(new Rect(0, 0, 1000, 1000), "Score: " + currentScore.ToString(), style);

        GUI.Label(new Rect(1200, 0, 1000, 1000), "Time: " + Mathf.Round(Time.time), style);

        GUI.Label(new Rect(600, 0, 1000, 1000), "Health: " + stats.health.ToString(), style);
    }



    public void increaseScore()
    {
      
        currentScore += Mathf.Round(5 * Time.time);
       
    }
}
