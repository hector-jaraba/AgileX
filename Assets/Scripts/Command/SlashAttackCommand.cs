using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttackCommand : ICommand {


    public void Execute( PlayerController player) {
        SlashAttack(player);
    }

    void SlashAttack(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.X))
            player.Animations.SetTrigger("loading");
        else if (Input.GetKeyUp(KeyCode.X))
        {
            player.oldCommands.Add(this);
            player.Animations.SetTrigger("Attack");
            player.audio.PlayOneShot(player.audioAtaque);
            player.Slash();
        }
    }
}
