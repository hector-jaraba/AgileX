using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntosImplement : MonoBehaviour {

    private Text puntuacion;
    private int puntosTotal = 20;

    void Start () {
        puntuacion = GetComponent<Text>();
        puntuacion.text = "Puntos: " + puntosTotal;
    }

    public int getPuntos(){return this.puntosTotal;}

    public void SumarPuntos(int puntos) {
        puntosTotal += puntos;
        puntuacion.text = "Puntos: " + puntosTotal;
    }

    public void RestarPuntos(int puntos)
    {
        puntosTotal -= puntos;
        puntuacion.text = "Puntos: " + puntosTotal;
    }
}
