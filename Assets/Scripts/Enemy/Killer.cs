using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy
{
    // Start is called before the first frame update
    protected override void PlayerImpact(Player player)
    {
        //base.PlayerImpact(player);
        player.Kill();
    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
