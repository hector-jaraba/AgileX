using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraArma : MonoBehaviour {

    public GameObject estadoJuego;
    // Use this for initialization
    void Start () {
        estadoJuego = GameObject.Find("EstadoJuego");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            estadoJuego.GetComponent<Estado>().mejoraArma = 1;
            Destroy(gameObject);
        }
 
    }

}
