using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public int puntos = 5;

    private ContadorPuntosImplement contadorPuntos;

    private void Awake()
    {
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            Destroy(this.gameObject);
            contadorPuntos.SumarPuntos(puntos);
        }
    }



}
