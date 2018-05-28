using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Estado : MonoBehaviour {

    public int mejoraArma { get; set; }
    public string username { get; set; }
    public GameObject name;
    
    public SortedList<int, string> listaRanking { get; set; }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
       // username = name.GetComponent<InputField>().text;
        
    }

    public void GuardarRanking()
    {
        Ranking lineaRanking = new Ranking();
        listaRanking.Add(lineaRanking.puntuacion, lineaRanking.username);
        GuardarEnBinario();
    }

   

    public void GuardarEnBinario()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/resultadoRanking.dat", FileMode.Open);
        
        formatter.Serialize(file, listaRanking);
        file.Close();
    }

    public void RecuperarDeBinario()
    {
        if(File.Exists(Application.persistentDataPath + "/resultadoRanking.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/resultadoRanking.dat", FileMode.Open);
            listaRanking = (SortedList<int, string>)formatter.Deserialize(file);
            file.Close();
        }
    }

}
