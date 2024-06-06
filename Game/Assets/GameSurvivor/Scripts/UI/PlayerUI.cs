using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private DamageUI damageUI;
    [SerializeField] private Image cooldownImage;

    public void ShowDamage(float damage)
    {
        damageUI.Play(damage);
    }

    public void UpdateColldown(float passedTime, float maxTime)
    {
        float normalizedTime = passedTime / maxTime;
        cooldownImage.fillAmount = normalizedTime;
    }
}
