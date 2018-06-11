using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand {


    public void Execute(PlayerController player)
    {
        PlayerAttack(player);
    }

    void AttackColliderUpdate(PlayerController player)
    {

        if (player.Sprite.flipX)
        {
            player.AttackCollider.offset = new Vector2(-0.6f, 0);
        }
        else
        {
            player.AttackCollider.offset = new Vector2(0.6f, 0);
        }

    }

    void PlayerAttack(PlayerController player)
    {
        AttackColliderUpdate(player);
        AnimatorStateInfo stateInfo = player.Animations.GetCurrentAnimatorStateInfo(0);
        bool isAttacking = stateInfo.IsName("Player_attack");
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            player.Animations.SetTrigger("Attack");
            player.audio.PlayOneShot(player.audioAtaque);
        }

        if (isAttacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66)
            {
                player.AttackCollider.enabled = true;
            }
            else
            {
                player.AttackCollider.enabled = false;
            }

        }

    }

}
