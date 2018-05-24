using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {

    // Use this for initialization
    public float waitBeforeDestroy;
    private Rigidbody2D slashRB;
    public float speed;
    private Transform playerTrans;

    void Awake()
    {
        slashRB = GetComponent<Rigidbody2D>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
            
    }
    // Update is called once per frame
    void Update()
    {
  
    }

    IEnumerator OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Object")
        {
            yield return new WaitForSeconds(waitBeforeDestroy);
            Destroy(gameObject);

        }
        else if (colision.tag == "Untagged" || colision.tag == "Ground")
            Destroy(gameObject);
    }
}
