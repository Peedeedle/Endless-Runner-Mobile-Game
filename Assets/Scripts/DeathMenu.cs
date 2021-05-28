using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    
    // Load menu scene
    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
    }


    // Restart Game by calling reset function on GameManager
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }


}
