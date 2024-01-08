using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{
    
    private Asteroid1 asteroid1;

    private void Start()
    {
        asteroid1 = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Asteroid1>();

    }


    private void OnGUI()
    {

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;


        GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 1000, 1000), "+" + asteroid1.deathScore, style);
        Destroy(gameObject, 0.5f);

    }

    
}
