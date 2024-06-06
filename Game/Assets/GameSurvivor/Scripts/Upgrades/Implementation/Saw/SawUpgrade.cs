using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SawUpgrade : Upgrade
{
    [SerializeField] private Saw sawPrefab;
    
    public override void Apply(Player player)
    {
        var saw = Instantiate(sawPrefab, player.transform.position, Quaternion.identity);
        saw.transform.SetParent(player.transform, true);
    }
}