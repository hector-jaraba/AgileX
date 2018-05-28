using System;
using System.Collections.Generic;

using System.Text;
using UnityEngine;

[Serializable()]
    public class Ranking 
    {
    public string username { get; set; }
    public int puntuacion { get; set; }

    public Ranking()
    {
        username = GameObject.Find("EstadoJuego").GetComponent<Estado>().username;
        puntuacion = GameObject.Find("ContadorPuntos").GetComponent<ContadorPuntosImplement>().getPuntos();
    }


    }

