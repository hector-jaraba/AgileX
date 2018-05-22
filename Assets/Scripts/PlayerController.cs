using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool screenUI = false; //used BarManager
    private bool jump;
    public bool movement = true;
    private bool disableMovement;
    public bool grounded;

    public int puntosGanar = 50;

    public float speed = 75f;
    public float maxSpeed = 3f;
    public float jumpPower = 9.35f;
    public float knockPower = 6.5f;

    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    public BarManager BarManager;
    private GameObject energyBar;
    private GameObject lifeBar;
    private UIManager uiManager;
    public GameObject slashPrefab;

    private CircleCollider2D attackCollider;
    private Rigidbody2D playerRigidBody;
    private Animator animations;
    private SpriteRenderer sprite;
    private SpriteRenderer dmgSprite;
    private ContadorPuntosImplement contadorPuntos;

    private void Awake()
	{
        gameOverScreen = GameObject.Find("GameOver");
        winScreen = GameObject.Find("WinScreen");
        pauseScreen = GameObject.Find("PauseScreen");
        energyBar = GameObject.Find("EnergyBar");
        lifeBar = GameObject.Find("LifeBar");
        BarManager = GameObject.Find("BarManager").GetComponent<BarManager>();
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

	void Start () {
        //buscamos los componentes internos
        playerRigidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmgSprite = GetComponent<SpriteRenderer>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
    }

    void FixedUpdate()
    {
        if (contadorPuntos.getPuntos() >= puntosGanar){
            Win();
        } 

        if (movement) {
            // detecto la direccion en el eje horizontal
            float h = Input.GetAxis("Horizontal");

            //le aplico una fuerza
            playerRigidBody.AddForce(Vector2.right * speed * h);

            //con la funcion clamp de la libreria mathf puedo poner un limite a la velocidad
            float limitedSpeed = Mathf.Clamp(playerRigidBody.velocity.x, -maxSpeed, maxSpeed);
            playerRigidBody.velocity = new Vector2(limitedSpeed, playerRigidBody.velocity.y);

            if (h > 0.1f){sprite.flipX = false;}

            if (h < -0.1f){sprite.flipX = true;}

            if (jump){
                playerRigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jump = false;
            }
        }

        animations.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        animations.SetBool("Grounded", grounded);
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            jump = true;
        }

        if (!movement) disableMovement = true;

        if (Input.GetKeyDown(KeyCode.Escape)) { Pause(); }

        Attack();

        SlashAttack();
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

        Invoke("EnableMovement", 0.7f);
        dmgSprite.color = Color.red;
        if (BarManager.getDamage() < 100) {BarManager.doDamage(10);}   

        contadorPuntos.RestarPuntos(5);
        if (contadorPuntos.getPuntos() <= 0 || BarManager.getDamage() == 100) {
            EndGame();
        }

    }

    public void SimpleDamage(float enemyPosX)
    {
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        Debug.Log(side);
        playerRigidBody.AddForce(Vector2.left * (side * 0.05f), ForceMode2D.Impulse);

        Invoke("EnableMovement", 0.7f);
        dmgSprite.color = Color.red;
        if (BarManager.getDamage() < 100) {
            BarManager.doDamage(10);
        }       

        contadorPuntos.RestarPuntos(5);
        if (contadorPuntos.getPuntos() <= 0 || BarManager.getDamage() == 100)
        {
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

    void SlashAttack()
    {
        AttackColliderUpdate();
        AnimatorStateInfo stateInfo = animations.GetCurrentAnimatorStateInfo(0);
        bool loading = stateInfo.IsName("Player_slash_attack");
        if (Input.GetKeyDown(KeyCode.X))
            animations.SetTrigger("loading");
        else if (Input.GetKeyUp(KeyCode.X))
        {
            animations.SetTrigger("Attack");

            GameObject slashObj = Instantiate(slashPrefab, transform.position, Quaternion.identity);
            Slash slash = slashObj.GetComponent<Slash>();
            slash.movimiento.x = animations.GetFloat("speed");
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

    public void EnableMovement()
    {
        movement = true;
        dmgSprite.color = Color.white;
    }

    void DisableMovement() {
        movement = false;
    }

    private void Win()
    {
        /*
        movement = false;
        screenUI = true;
        winScreen.SetActive(true);
        energyBar.SetActive(false);
        */
        uiManager.Launch(winScreen.GetComponent<WinUI>());
    }

    private void EndGame()
    {
        /*
        movement = false;
        screenUI = true;
        Debug.Log("movimiento" + movement);
        gameOverScreen.SetActive(true);
        energyBar.SetActive(false);
        */

        uiManager.Launch(winScreen.GetComponent<GameOverUI>());
    }

    private void Pause()
    {
        /*
        movement = false;
        screenUI = true;
        Debug.Log("Pause Menu");
        pauseScreen.GetComponent<PauseUI>().GameIsPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        */

        uiManager.Launch(pauseScreen.GetComponent<PauseUI>());
    }
}
