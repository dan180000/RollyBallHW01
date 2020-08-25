using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{

    Vector3 offset;

    protected override void PlayerImpact(Player player)
    {
        player.transform.position = transform.position + offset;
        Debug.Log("Bounce!");
    }
}
