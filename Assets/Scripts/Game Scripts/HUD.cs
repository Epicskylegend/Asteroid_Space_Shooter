using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private Stats stats;

    public float currentScore = 0;
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnGUI() 
    {
        
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24; 

        GUI.Label(new Rect(0, 0, 1000, 1000), "<color=cyan>Score: </color> "  + currentScore.ToString(), style);

        GUI.Label(new Rect(1250, 0, 1000, 1000), "Time: " + Mathf.Round(Time.time), style);

        GUI.Label(new Rect(650, 0, 1000, 1000), "<color=green>Health:</color> " + stats.health.ToString(), style);
    }



    public void increaseScore()
    {
      
        currentScore += Mathf.Round(5 * Time.time);
       
    }
}
