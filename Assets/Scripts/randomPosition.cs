using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour {

    public float fallDelay = 0.2f;
    public float respawnDelay = 4f;

    private Rigidbody2D rb2d; //forces interact
    private PolygonCollider2D pc2d;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        //pc2d.isTrigger = true;
    }

    void Respawn()
    {
        transform.rotation = startRotation;
        transform.position = startPosition;
        
        rb2d.velocity = Vector3.zero; //( 0f, 0f, 0f)
        rb2d.angularVelocity = 0f;
        //pc2d.isTrigger = false;

    }
}
