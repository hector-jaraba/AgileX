using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text contador;
    public Text finDeTiempo;
    public float tiempo;


    public void Start()
    {
        contador.text = "" + tiempo;
        finDeTiempo.enabled = false;
    }
    public void Update()
    {
        tiempo -= Time.deltaTime;
        contador.text = "" + tiempo.ToString("f0");
        if(tiempo <= 5)
        {
            contador.color = Color.red;
        }
        if (tiempo <= 0)
        {
            contador.enabled = false;
            finDeTiempo.enabled = true;
        }
            
    }
}
