using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    AudioManager audioManager;

    void OnTriggerEnter2D()
    {
        
        gameManager.CompleteLevel();
        Time.timeScale = 0f;
    }
}
