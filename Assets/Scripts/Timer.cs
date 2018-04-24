using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float tiempo;
    Text contadorTimer;
    public GameObject player;
    

    // Use this for initialization
    void Start () {


        contadorTimer = GetComponent<Text>(); 
        contadorTimer.text = "" + tiempo;
        player= GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {

        tiempo -= Time.deltaTime;
        contadorTimer.text = "" + tiempo.ToString("f0");
        if (tiempo <= 5) {
            contadorTimer.color = Color.red;
        }

        if (tiempo <= 0) {
            contadorTimer.text = "0";
            player.SendMessage("EndGame");
        }
            


    }
}
