using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class UpgradesUIManager : MonoBehaviour
{
    [SerializeField] private UpgradeUI upgradeUIPrefab;
    [SerializeField] private UpgradesManager upgradesManager;

    public void Show(List<Upgrade> upgrades, Player player)
    {
        gameObject.SetActive(true);

        foreach(Transform child in transform)
            Destroy(child.gameObject);

        foreach (var upgrade in upgrades)
        {
            var ui = Instantiate(upgradeUIPrefab, transform);
            ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(upgrade, player));

        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void OnClickApply(Upgrade upgrade, Player player)
    {
        upgrade.Apply(player);
        upgradesManager.OnUpgradeApplied(upgrade);
    }
}