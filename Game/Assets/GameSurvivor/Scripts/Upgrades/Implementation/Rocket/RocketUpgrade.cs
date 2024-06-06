using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpgrade : Upgrade
{   
    [SerializeField] private RocketLauncher launcherPrefab;

    public override void Apply(Player player)
    {
        var launcher = Instantiate(launcherPrefab, player.transform.position, Quaternion.identity);
        launcher.transform.SetParent(player.transform, true);
    }
}
