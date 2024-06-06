using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private UpgradesUIManager uiManager;
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private Player player;

    private List<Upgrade> availabelUpgrades;

    public void Awake()
    {
        availabelUpgrades = upgrades.ToList();
    }
    
    public void Suggest()
    {
        if (availabelUpgrades.Count > 0)
        {
            Time.timeScale = 0;
            uiManager.Show(availabelUpgrades, player);
        }
    }
    
    public void OnUpgradeApplied(Upgrade appliedUpgrade)
    {
        uiManager.Hide();
        availabelUpgrades.Remove(appliedUpgrade);
        Time.timeScale = 1;
    }
}
