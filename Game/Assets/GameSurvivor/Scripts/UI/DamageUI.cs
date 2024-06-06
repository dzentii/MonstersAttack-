using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    [SerializeField] private Text damageText;
    [SerializeField] private Animator animator;
    [SerializeField] private string stateName;

    public void Play(float damage)
    {
        damageText.text = damage.ToString();
        animator.Play(stateName, -1, 0);
    }
}
