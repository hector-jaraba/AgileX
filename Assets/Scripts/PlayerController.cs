using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 5f;
    public bool grounded;
    public float jumpPower = 6.5f;

    private Rigidbody2D playerRigidBody;
    private Animator animations;
    private SpriteRenderer sprite;
    private bool jump;

	// Use this for initialization
	void Start () {
        //buscamos los componentes internos
        playerRigidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        animations.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        animations.SetBool("Grounded", grounded);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded) {
            jump = true;
        }

        

    }

    void FixedUpdate()
    {
        // detecto la direccion en el eje horizontal
        float h = Input.GetAxis("Horizontal");

        //le aplico una fuerza
        playerRigidBody.AddForce(Vector2.right * speed * h);


        //con la funcion clamp de la libreria mathf puedo poner un limite a la velocidad
        float limitedSpeed = Mathf.Clamp(playerRigidBody.velocity.x, -maxSpeed, maxSpeed);
        playerRigidBody.velocity = new Vector2(limitedSpeed, playerRigidBody.velocity.y);

        if (h > 0.1f) {
            sprite.flipX = false;
        }

        if (h < -0.1f)
        {
            sprite.flipX = true;
        }

        if (jump) {
            playerRigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem") {
            Destroy(collision.gameObject);
        }
    }
}
