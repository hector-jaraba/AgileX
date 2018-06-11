using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSuperpower : Superpower {

    public override void Activate(PlayerController player)
    {
        Speed(player);
    }

    public override void Speed(PlayerController player)
    {
        player.speed = player.speed * 1.5f;
    }

    public override void Jump(PlayerController player)
    {
        throw new System.NotImplementedException();
    }
 
}
