using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSuperpower : Superpower {

    public override void Activate(PlayerController player)
    {
        Jump(player);
    }

    public override void Jump(PlayerController player)
    {
        player.jumpPower = player.jumpPower * 1.5f;
    }

    public override void Speed(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

}
