using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    

   // Load game scene
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }

}
