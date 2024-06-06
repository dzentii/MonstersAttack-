using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsUpgrade : Upgrade
{
    [SerializeField] private int increment;
    public override void Apply(Player player)
    {
        player.BulletsCount += increment;
    }
}
