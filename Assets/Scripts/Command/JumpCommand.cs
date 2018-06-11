using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand {

    public void Execute(PlayerController player) {
     
        player.PlayerRigidBody.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);
        player.audio.PlayOneShot(player.audioSaltar);
        player.Jump = false;
    }
}
