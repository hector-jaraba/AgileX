using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour {


    public int puntosVida = 25;
    public float primeraAparicion = 0.2f;
    public int respawnDelay = 10;
    public float botiquinPositionY = 10.0f;
    public float maxBotiquinPositionX = 8.0f;
    public float minBotiquinPositionX = -8.0f;


    private float fallDelay = 1f;
    private Rigidbody2D rb2d; //forces interact
    private BoxCollider2D pc2d;
    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;

    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("Respawn", primeraAparicion, respawnDelay);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //puntuacion.text = "Puntos: " + "50";
            Invoke("Fall", fallDelay);
            Invoke("Respawn", 0.2f);
            transform.localScale = new Vector3(0.5f, 0.5f);
            EnergyRestore();
            //pc2d.isTrigger = true;
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        //PolygonCollider2D
    }

    void EnergyRestore()
    {
        int maxHealth = 0;
        if (player.damage <= puntosVida)
        {
            player.damage = maxHealth;
        }
        else {
            player.damage -= puntosVida;
        }
    }

    void Respawn()
    {

        transform.rotation = startRotation;
        transform.position = new Vector3(Random.Range(minBotiquinPositionX, maxBotiquinPositionX), botiquinPositionY, 0.0f);
        transform.localScale = startScale;
        rb2d.velocity = Vector3.zero; //( 0f, 0f, 0f)
        rb2d.angularVelocity = 0f;
        pc2d.isTrigger = false;
    }

}


