using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthImage;

    [SerializeField] private Text levelText;

    [SerializeField] private Text timerText;

    public void SetHealth(float health, float maxHealth)
    {
        var normalizedHealth = health / maxHealth;
        healthImage.fillAmount = normalizedHealth;
    }

    public void SetLevel(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetTimer(float timer)
    {
        var span = TimeSpan.FromSeconds(timer);
        timerText.text = span.ToString(@"\:mm\-ss");
    }
}
