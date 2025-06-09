using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    public GameObject completeLevelUI;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
    if (PauseMenu.GameisPaused || gameOverUI.activeInHierarchy || completeLevelUI.activeInHierarchy)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    else
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}


    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PlaySFX(audioManager.GameOver);
        
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        audioManager.PlaySFX(audioManager.portal);
    }

    public void Next()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
        Debug.Log("Credits!");
    }
}

