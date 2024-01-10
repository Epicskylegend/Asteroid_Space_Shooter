using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{
  
    private ScoreHUD hud;
    public float deathScore = 0;


    private void Start()
    {
    

    }

    private void OnGUI()
    {

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;


        GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 1000, 1000), "+" + deathScore, style);
        Destroy(gameObject, 0.5f);

    }

    
}
