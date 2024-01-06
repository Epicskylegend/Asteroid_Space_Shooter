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
        GUI.Label(new Rect(0, 0, 1000, 1000), "Score: " + currentScore.ToString());
    }

    public void increaseScore()
    {
      
        currentScore += 100;
       
    }
}
