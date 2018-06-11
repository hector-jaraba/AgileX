using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : ICommand {

    GameObject player;
    PlayerController PlayerController;

    public void Execute(PlayerController player) {
        PlayerRun(player);
    }

    public void PlayerRun(PlayerController player) {
        

        // detecto la direccion en el eje horizontal
    

        //le aplico una fuerza
        player.PlayerRigidBody.AddForce(Vector2.right * player.speed * player.h);

        //con la funcion clamp de la libreria mathf puedo poner un limite a la velocidad
        float limitedSpeed = Mathf.Clamp(player.PlayerRigidBody.velocity.x, -player.maxSpeed, player.maxSpeed);
        player.PlayerRigidBody.velocity = new Vector2(limitedSpeed, player.PlayerRigidBody.velocity.y);

        if (player.h > 0.1f) { player.Sprite.flipX = false; }

        if (player.h < -0.1f) { player.Sprite.flipX = true; }

    }
}
