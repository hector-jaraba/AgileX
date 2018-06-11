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
    //No tiene mejora en el arma

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
    public GameObject estadoJuego;
    public float h;
    public AudioClip audioSaltar;
    public AudioClip audioAtaque;
    public AudioClip audioDanyo;
    public AudioSource audio;


    private CircleCollider2D attackCollider;
    private Rigidbody2D playerRigidBody;
    private Animator animations;
    private SpriteRenderer sprite;
    private SpriteRenderer dmgSprite;
    private ContadorPuntosImplement contadorPuntos;

    public List<ICommand> oldCommands = new List<ICommand>();

    private ICommand keyZ, KeyX, KeyUp, KeysHorizontal;

    public bool Jump
    {
        get
        {
            return jump;
        }

        set {
            jump = value;
        }
    }

    public Rigidbody2D PlayerRigidBody
    {
        get
        {
            return playerRigidBody;
        }
    }

    public SpriteRenderer Sprite
    {
        get
        {
            return sprite;
        }
    }

    public CircleCollider2D AttackCollider
    {
        get
        {
            return attackCollider;
        }
    }

    public Animator Animations
    {
        get
        {
            return animations;
        }
    }

    private void Awake()
	{
        estadoJuego = GameObject.Find("EstadoJuego");
        gameOverScreen = GameObject.Find("GameOver");
        winScreen = GameObject.Find("WinScreen");
        pauseScreen = GameObject.Find("PauseScreen");
        energyBar = GameObject.Find("EnergyBar");
        lifeBar = GameObject.Find("LifeBar");
        BarManager = GameObject.Find("BarManager").GetComponent<BarManager>();
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        audio = GetComponent<AudioSource>();

        
    }

	void Start () {
        //buscamos los componentes internos
        playerRigidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmgSprite = GetComponent<SpriteRenderer>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();

        keyZ = new AttackCommand();
        KeyX = new SlashAttackCommand();
        KeyUp = new JumpCommand();
        KeysHorizontal = new RunCommand();
    }

    void FixedUpdate()
    {
        if (contadorPuntos.getPuntos() >= puntosGanar){
            Win();
        } 

        if (movement) {
            h = Input.GetAxis("Horizontal");
            KeysHorizontal.Execute(this);

            if (Jump){
                KeyUp.Execute(this);
            }
        }

        Animations.SetFloat("Speed", Mathf.Abs(playerRigidBody.velocity.x));
        Animations.SetBool("Grounded", grounded);
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            jump = true; 
        }

        if (!movement) disableMovement = true;

        if (Input.GetKeyDown(KeyCode.Escape)) { Pause(); }

        keyZ.Execute(this);

        if(estadoJuego.GetComponent<Estado>().mejoraArma == 1)
        {
            KeyX.Execute(this);
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log(oldCommands[oldCommands.Count-1]);
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
        audio.PlayOneShot(audioDanyo);

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
        playerRigidBody.AddForce(Vector2.left * (side * 0.05f), ForceMode2D.Impulse);
        audio.PlayOneShot(audioDanyo);

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


    public void Slash() {
        GameObject slashObj = Instantiate(slashPrefab, AttackCollider.transform.position, AttackCollider.transform.rotation);
        Slash slash = slashObj.GetComponent<Slash>();
        Rigidbody2D slashRB = slash.GetComponent<Rigidbody2D>();
        if (Sprite.flipX)
        {
            slashRB.velocity = new Vector2(-slash.speed, slashRB.velocity.y);
            slash.transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            slashRB.velocity = new Vector2(slash.speed, slashRB.velocity.y);
            slash.transform.localScale = new Vector3(1, 1, 1);
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
        uiManager.Launch(winScreen.GetComponent<WinUI>());
    }

    private void EndGame()
    {
        uiManager.Launch(gameOverScreen.GetComponent<GameOverUI>());
    }

    private void Pause()
    {
        uiManager.Launch(pauseScreen.GetComponent<PauseUI>());
    }
}
