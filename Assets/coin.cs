using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public int points = 0;




    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            Destroy(this.gameObject);
        }
    }



}
