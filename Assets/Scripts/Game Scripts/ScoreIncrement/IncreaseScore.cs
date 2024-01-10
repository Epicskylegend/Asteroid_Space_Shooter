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
        /*  private void OnGUI()
          {

              Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
              GUIStyle style = new GUIStyle(GUI.skin.label);
              style.fontSize = 24;


              GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 1000, 1000), "+" + deathScore, style);
              Destroy(gameObject, 0.5f);

          }*/


    }

