using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHUD : MonoBehaviour
{
    public TMP_Text timerText;
    void Start()
    {
        
    }

    void Update()
    {
        timerText.SetText("Time: " + Mathf.Round(Time.time) );
    }
}
