using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] int powerupDuration = 5;

    protected override void PowerUp(Player player)
    {
        player.PowerUp(powerupDuration);
    }

    protected override void PowerDown(Player player)
    {
        player.PowerDown(powerupDuration);
    }
}
