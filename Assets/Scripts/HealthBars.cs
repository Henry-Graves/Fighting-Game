using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public Image Player1Health;
    public Image Player2Health;
    private float P1MaxHealth;
    private float P2MaxHealth;

    // Set initial health values for loaded characters
    void Start()
    {
        P1MaxHealth = StatsManager.P1Health;
        P2MaxHealth = StatsManager.P2Health;
    }

    // Update healthbars per frame based on percent health remaining
    void Update()
    {
        Player1Health.fillAmount = StatsManager.P1Health / P1MaxHealth;
        Player2Health.fillAmount = StatsManager.P2Health / P2MaxHealth;
    }
}
