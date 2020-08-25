using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureIncrease : CollectibleBase
{
    [SerializeField] int treasureAdded = 1;
    protected override void Collect(Player player)
    {
        player.IncreaseTreasure(treasureAdded);
    }
}
