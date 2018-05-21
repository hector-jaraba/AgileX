using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour, IScreenManager {

    public bool GameIsPaused;

    public GameObject pauseMenuUI;
    public PlayerController playerController;

    public void Start()
    {
        gameObject.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void Active()
    {
        playerController.movement = false;
        playerController.screenUI = true;
        GameIsPaused = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        playerController.EnableMovement();
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        GameIsPaused = true;
    }

    public void Quit(string nombre)
    {
        Debug.Log("Aplication Quit");
        SceneManager.LoadScene(nombre);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
