 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start point for all variables
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;


    // Platform destroyer array
    private PlatformDestroyer[] platformList;

    // score manager reference on start and to reset when player dies
    private ScoreManager theScoreManager;

    // Reference to death screen
    public DeathMenu theDeathScreen;

    // Bool to reset powerups
    public bool powerupReset;


    // Start is called before the first frame update
    void Start()
    {
        // At startup take player position and platform start position and find the score manager
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // 
    void Update()
    {
        
    }

    // Start Coroutine to add time before restart
    public void RestartGame()
    { 
        // Stop score increasing
        theScoreManager.scoreIncreasing = false;

        // Set player to false then wait 0.5 seconds then reset everything to the start then set the player to true
        thePlayer.gameObject.SetActive(false);

        // Set death screen to true and visible
        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    //
    public void Reset()
    {
        // Set death screen to true and visible
        theDeathScreen.gameObject.SetActive(false);

        // Find all objects with "platformDestroyer" script and set to false when player "dies"
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        // Reset the players values like the start position
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        // Set the score back to 0 and set the score to increase
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

        // Reset all powerups 
        powerupReset = true;
    }
}


// Coroutine code
/*public IEnumerator RestartGameCo()
{


    yield return new WaitForSeconds(0.5f);

    // Find all objects with "platformDestroyer" script and set to false when player "dies"
    platformList = FindObjectsOfType<PlatformDestroyer>();
    for (int i = 0; i < platformList.Length; i++)
    {
        platformList[i].gameObject.SetActive(false);
    }

    thePlayer.transform.position = playerStartPoint;
    platformGenerator.position = platformStartPoint;
    thePlayer.gameObject.SetActive(true);

    // Set the score back to 0 and set the score to increase
    theScoreManager.scoreCount = 0;
    theScoreManager.scoreIncreasing = true;
}

}*/
