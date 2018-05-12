using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 75f;
    public float maxSpeed = 3f;
    public bool grounded;
    public float jumpPower = 9.35f;
    public float knockPower = 6.5f;    
    
    public Image health;
    public Image life;
    public float energy = 100;
    public float damage = 100;
    public int puntosGanar = 50;

    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject healthBar;
    public GameObject lifeBar;

    private CircleCollider2D attackCollider;
    private Rigidbody2D playerRigidBody;
    private Animator animations;
    private SpriteRenderer sprite;
    private SpriteRenderer dmgSprite;
    public bool screenUI = false;
    private bool jump;
    private bool movement = true;
    private bool flag = true;
    private bool disableMovement;

    float timer = 0.0f;
    float timeMax = 0.05f;
    float increment = 0.0f;

    int tiempo = 50;

    public ContadorPuntosImplement contadorPuntos;

    private void Awake()
	{
        gameOverScreen = GameObject.Find("GameOver");
        winScreen = GameObject.Find("WinScreen");
        healthBar = GameObject.Find("HealthBar");
        lifeBar = GameObject.Find("LifeBar");
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
    }

	// Use this for initialization
	void Start () {
        //buscamos los componentes internos
        playerRigidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmgSprite = GetComponent<SpriteRenderer>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();

        
    }

    public void ActualizarHealthLifeBar() {

        timer += Time.deltaTime;
        increment = 0.2f;

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)) && energy >= 0){
            energy -= increment;
            flag = false;
        } else{
            if(energy < 100 && flag){
                    energy += 0.3f;                
                flag = false;
            }
        }            

        health.transform.localScale = new Vector2(energy / 100f, 1);
        life.transform.localScale = new Vector2(damage / 100f, 1);

        // flag para controlar que solo crezca la energia cada 5 segundos
        if (timer >= timeMax){
            flag = true;
            timer = 0.0f;
            
        } 


        // Si se queda sin energia o aparece alguna pantalla UI no se puede mover 
        if (energy <= 0)
        {
            movement = false;
        }
        else if (energy > 5 && !screenUI){
            movement = true;
        } 
    }
	
	// Update is called once per frame
	void Update () {


        animations.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        animations.SetBool("Grounded", grounded);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded) {
            jump = true;
        }

        if (!movement) disableMovement = true;



        Attack();
    }

    void FixedUpdate()
    {
        ActualizarHealthLifeBar();
        if (contadorPuntos.getPuntos() >= puntosGanar){
            Win();
        } 

        // el jugador no se puede mover
        if (movement) {

            // detecto la direccion en el eje horizontal
            float h = Input.GetAxis("Horizontal");

            //le aplico una fuerza
            playerRigidBody.AddForce(Vector2.right * speed * h);


            //con la funcion clamp de la libreria mathf puedo poner un limite a la velocidad
            float limitedSpeed = Mathf.Clamp(playerRigidBody.velocity.x, -maxSpeed, maxSpeed);
            playerRigidBody.velocity = new Vector2(limitedSpeed, playerRigidBody.velocity.y);

            if (h > 0.1f)
            {
                sprite.flipX = false;
                
            }

            if (h < -0.1f)
            {
                sprite.flipX = true;
                
            }

            if (jump)
            {
                playerRigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jump = false;

            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "GameOver") {
            EndGame();
            screenUI = true;
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
        damage -= 10;
        contadorPuntos.RestarPuntos(5);
        if (contadorPuntos.getPuntos() <= 0 || damage <= 0) {
            EndGame();
        }

    }


    void Attack()
    {
        AttackColliderUpdate();
        AnimatorStateInfo stateInfo = animations.GetCurrentAnimatorStateInfo(0);
        bool isAttacking = stateInfo.IsName("Player_attack");
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            animations.SetTrigger("Attack");
        }

        if (isAttacking) {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66)
            {
                attackCollider.enabled = true;
            }
            else {
                attackCollider.enabled = false;
            }

        }

    }

    void AttackColliderUpdate() {

        if (sprite.flipX)
        {
            attackCollider.offset = new Vector2(-0.6f, 0);
        }
        else {
            attackCollider.offset = new Vector2(0.6f, 0);
        }

    }

    void EnableMovement()
    {
        //movement = true;
        dmgSprite.color = Color.white;
    }

    void DisableMovement() {
        movement = false;
    }

    private void Win()
    {
        movement = false;
        screenUI = true;
        winScreen.SetActive(true);
        healthBar.SetActive(false);


    }

    // acaba el juego
    private void EndGame()
    {
        movement = false;
        screenUI = true;
        Debug.Log("movimiento" + movement);
        gameOverScreen.SetActive(true);
        healthBar.SetActive(false);
    }
}
