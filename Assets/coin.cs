using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public int points = 0;

    private BoxCollider2D GameObjectCoin;
    private CircleCollider2D GameObjectCoinCircle;



    // Use this for initialization
    void Start()
    {
        GameObjectCoin = GetComponent<BoxCollider2D>();
        GameObjectCoinCircle = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            transform.localScale = new Vector3(0.5f, 0.5f);
            Destroy(GameObjectCoin);
            Destroy(GameObjectCoinCircle);
            new WaitForSeconds(0.4f);
            transform.localScale = new Vector3(0.05f, 0.05f);
        }
    }



}
