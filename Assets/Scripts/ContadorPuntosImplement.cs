using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntosImplement : MonoBehaviour
{

    public int puntosTotal = 40;
    private Text puntuacion;

    //Singleton pattern
    private static ContadorPuntosImplement _instance;

    public static ContadorPuntosImplement Instance { get { return _instance; } }

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            this.gameObject.name = "ContadorPuntosText";
        }



    }
    //


    void Start()
    {
        puntuacion = GetComponent<Text>();
        puntuacion.text = "Puntos: " + Instance.puntosTotal;
    }

    public int getPuntos()
    {
        return Instance.puntosTotal;
    }

    public void SumarPuntos(int puntos)
    {
        Instance.puntosTotal += puntos;
        puntuacion.text = "Puntos: " + Instance.puntosTotal;
    }

    public void RestarPuntos(int puntos)
    {
        Instance.puntosTotal -= puntos;
        puntuacion.text = "Puntos: " + Instance.puntosTotal;
    }
}
