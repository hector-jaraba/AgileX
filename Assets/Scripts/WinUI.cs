using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Quit(string nombre)
    {
        //Debug.Log("Aplication Quit");
        print("Volviendo a " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void NextLevel(string nombre)
    {
        print("Cargando siguiente nivel: " + nombre);
        SceneManager.LoadScene(nombre);
    }
}
