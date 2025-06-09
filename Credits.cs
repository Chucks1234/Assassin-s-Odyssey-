using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    private GameObject Credits1;
    public void MainScreen()
    
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu");
    }
}
