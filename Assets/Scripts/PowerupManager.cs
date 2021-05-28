using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // public variables for the length the powerups last and what they are called
    private bool doublePoints;
    private bool safeMode;

    // Is powerup active
    private bool powerupActive;

    // Variable for powerup length counter
    private float powerupLengthCounter;

    // Link other scripts to this one and apply references
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    //Game manager link to script
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float rockRate;

    // Array for the rocks
    private PlatformDestroyer[] rockList;

    









    // Find the objects for other scripts
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If powerup is active set
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            // When player dies turn off all current powerups
            if (theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false;
            }

            // If double points is true then double the points
            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }

            // When safe mode is true do not generate any spikes for a specific amount of time
            if (safeMode)
            {
                thePlatformGenerator.randomRockThreshold = 0;
            }



            if (powerupLengthCounter <= 0)
            {
                // Set values back to normal and set the powerup to false
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;

                thePlatformGenerator.randomRockThreshold = rockRate;

                powerupActive = false;
            }




        }
    }

    // Activate powerups depending on which one is collected
    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        // Values for normal points and rock rate in this script
        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        rockRate = thePlatformGenerator.randomRockThreshold;

        if (safeMode)
        {
            // Find all objects with "platformDestroyer" script and set to false when player "dies"
            rockList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < rockList.Length; i++)
            {
                if (rockList[i].gameObject.name.Contains ("Rock Rubble"))
                {
                    rockList[i].gameObject.SetActive(false);
                }
                
            }
        }
        


        powerupActive = true;
    }

}
