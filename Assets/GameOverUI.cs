using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

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

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
