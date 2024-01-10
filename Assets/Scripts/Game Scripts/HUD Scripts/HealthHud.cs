using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthHud : MonoBehaviour
{
    private PlayerHealth player;

    public TMP_Text healthText;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();

    }
    void Update()
    {
        healthText.SetText("Health: " + player.health);
    }
}
