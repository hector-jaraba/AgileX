using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour, IScreenManager
{

    public void CambiarEscena(string nombre)
    {
        print("Cambiando a la escena " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        print("Saliendo del juego");
        Application.Quit();
    }

    public void Volver(string nombre)
    {
        //Debug.Log("Aplication Quit");
        print("Volviendo a " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Quit(string nombre)
    {
        //Debug.Log("Aplication Quit");
        print("Volviendo a " + nombre);
        SceneManager.LoadScene(nombre);
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
