using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour, IScreenManager{

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
        playerController.movement = false;
        playerController.screenUI = true;
        gameObject.SetActive(true);
        energyBar.SetActive(false);
        Debug.Log("Win UI");
    }

    public void Quit(string name)
    {
        Debug.Log("Aplication Quit: "+ name);
        SceneManager.LoadScene(name);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(string nombre)
    {
        print("Cargando siguiente nivel: " + nombre);
        SceneManager.LoadScene(nombre);
    }
}
