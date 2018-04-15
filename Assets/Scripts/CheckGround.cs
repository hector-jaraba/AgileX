using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();

	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            player.grounded = true;
        }
        

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            player.grounded = false;
        }
    }
}
