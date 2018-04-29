using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour {

    public int points = 0;

    public float primeraAparicion = 0.2f;
    public int respawnDelay = 10;
    public float GemPositionY = 10.0f;
    public float maxGemPositionX = 8.0f;
    public float minGemPositionX = -8.0f;


    private float fallDelay = 1f;
    private Rigidbody2D rb2d; //forces interact
    private BoxCollider2D pc2d;
    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;

        InvokeRepeating("Respawn", primeraAparicion, respawnDelay);

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            //puntuacion.text = "Puntos: " + "50";
            Invoke("Fall", fallDelay);
            Invoke("Respawn", 0.2f);
            transform.localScale = new Vector3(0.5f, 0.5f);
            //pc2d.isTrigger = true;
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        //PolygonCollider2D
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
