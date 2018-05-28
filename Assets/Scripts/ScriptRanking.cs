using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptRanking : MonoBehaviour {

    // Use this for initialization
    public Text username1;
    public Text username2;
    public Text username3;

    public Text puntuacion1;
    public Text puntuacion2;
    public Text puntuacion3;

    public SortedList<int, string> listaRanking;
    public GameObject estadoJuego;

    void Start () {
        estadoJuego = GameObject.Find("EstadoJuego");
        listaRanking = estadoJuego.GetComponent<Estado>().listaRanking;
        //RecuperarPosicion(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RecuperarPosicion()
    {
        IList<int> puntuaciones = listaRanking.Keys;
        IList<string> usernames = listaRanking.Values;

        for(int i = 0; i < puntuaciones.Count && i < 3; i++)
        {
            switch (i)
            {
                case 0: username1.text = usernames[i];
                    puntuacion1.text = puntuaciones[i].ToString();
                    break;
                case 1:
                    username2.text = usernames[i];
                    puntuacion2.text = puntuaciones[i].ToString();
                    break;
                case 2:
                    username3.text = usernames[i];
                    puntuacion3.text = puntuaciones[i].ToString();
                    break;
            } 
        }
        
    }
}

