using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour {

    public float primeraAparicion = 0.2f;
    public int respawnDelay = 10;
    public float GemPositionY = 10.0f;
    public float maxGemPositionX = 8.0f;
    public float minGemPositionX = -8.0f;
    public int puntos = 10;


    private float fallDelay = 1f;
    private Rigidbody2D rb2d;
    private BoxCollider2D pc2d;
    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;
    private Text puntuacion;

    private ContadorPuntosImplement contadorPuntos;
    
    private void Awake()
    {
       contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;
        InvokeRepeating("Respawn", primeraAparicion, respawnDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contadorPuntos.SumarPuntos(puntos);
            Invoke("Fall", fallDelay);
            Invoke("Respawn", 0.2f);
            transform.localScale = new Vector3(0.5f, 0.5f);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
    }

    void Respawn()
    {

        transform.rotation = startRotation;
        transform.position = new Vector3(Random.Range(minGemPositionX,maxGemPositionX), GemPositionY, 0.0f);
        transform.localScale = startScale;
        rb2d.velocity = Vector3.zero; //( 0f, 0f, 0f)
        rb2d.angularVelocity = 0f;
        pc2d.isTrigger = false;
    }

}
