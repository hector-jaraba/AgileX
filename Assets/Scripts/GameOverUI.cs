using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour, IScreenManager {

    private PlayerController playerController;
    private GameObject energyBar;

    public void Start()
    {
        gameObject.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        energyBar = GameObject.Find("EnergyBar");
    }

    public void Active()
    {
        gameObject.SetActive(true);
        playerController.movement = false;
        playerController.screenUI = true;
        energyBar.SetActive(false);
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
