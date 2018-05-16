using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntosImplement : MonoBehaviour {

    private Text puntuacion;

    void Start ()
    {
        puntuacion = GetComponent<Text>();
        puntuacion.text = "Puntos: " + Singleton.Instance.puntosTotal;
    }

    public int getPuntos()
    {
        return Singleton.Instance.puntosTotal;
    }

    public void SumarPuntos(int puntos)
    {
        Singleton.Instance.puntosTotal += puntos;
        puntuacion.text = "Puntos: " + Singleton.Instance.puntosTotal;
    }

    public void RestarPuntos(int puntos)
    {
        Singleton.Instance.puntosTotal -= puntos;
        puntuacion.text = "Puntos: " + Singleton.Instance.puntosTotal;
    }
}
