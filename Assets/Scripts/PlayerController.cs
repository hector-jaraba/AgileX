﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 75f;
    public float maxSpeed = 3f;
    public bool grounded;
    public float jumpPower = 9.35f;
    public float knockPower = 6.5f;
    public int contadorPuntos;
    public Text puntuacion;
    public Text contadorTimer;
    public float tiempo;
    public Image health;
    public float energy = 100;
    public int puntosGanar = 50;

    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public GameObject healthBar;

    private Rigidbody2D playerRigidBody;
    private Animator animations;
    private SpriteRenderer sprite;
    private SpriteRenderer dmgSprite;
    private bool ScreenUI = false;
    private bool jump;
    private bool movement = true;
    private bool flag = true;

	// Use this for initialization
	void Start () {
        //buscamos los componentes internos
        playerRigidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmgSprite = GetComponent<SpriteRenderer>();
        contadorPuntos = 25;
        puntuacion.text = "Puntos: " + contadorPuntos;
        contadorTimer.text = "" + tiempo;
    }

    public void ActualizarHealthBar() {

        if (energy <= 90 && (int)tiempo % 5 == 0 && flag){
            energy += 10;
            flag = false;
            
        } else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && energy >= 10)
            energy -= 10;

        health.transform.localScale = new Vector2(energy / 100f, 1);

        // flag para controlar que solo crezca la energia cada 5 segundos
        if ((int)tiempo % 2 != 0) flag = true;


        // Si se queda sin energia o aparece alguna pantalla UI no se puede mover 
        if (energy == 0)
        {
            movement = false;
        }
        else if (energy > 0 && !ScreenUI) movement = true;
    }
	
	// Update is called once per frame
	void Update () {

        ActualizarHealthBar();
        animations.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        animations.SetBool("Grounded", grounded);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded) {
            jump = true;
        }

        tiempo -= Time.deltaTime;
        contadorTimer.text = "" + tiempo.ToString("f0");
        if (tiempo <= 5)
            contadorTimer.color = Color.red;
        if (tiempo <= 0)
            contadorTimer.text = "0";
  
    }

    void FixedUpdate()
    {
        // detecto la direccion en el eje horizontal
        float h = Input.GetAxis("Horizontal");

        // el jugador no se puede mover
        if (!movement) h = 0;


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
<<<<<<< Updated upstream
            contadorPuntos = contadorPuntos + 5;
            puntuacion.text = "Puntos: " + contadorPuntos;
            if (contadorPuntos >= puntosGanar) Win();
=======
            int puntos = collision.GetComponent<Gem>().Puntos();
>>>>>>> Stashed changes
            Destroy(collision.gameObject);
        }

        if (collision.tag == "GameOver") {
            EndGame();
            ScreenUI = true;
        }

    }

   

    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        playerRigidBody.AddForce(Vector2.left * knockPower * side , ForceMode2D.Impulse);

        //movement = false;
        Invoke("EnableMovement", 0.7f);
        dmgSprite.color = Color.red;

    }

    void EnableMovement()
    {
        //movement = true;
        dmgSprite.color = Color.white;
    }

    private void Win()
    {
        movement = false;
        ScreenUI = true;
        WinScreen.SetActive(true);
        healthBar.SetActive(false);


    }

    // acaba el juego
    private void EndGame()
    {
        GameOverScreen.SetActive(true);
        healthBar.SetActive(false);
    }
}
