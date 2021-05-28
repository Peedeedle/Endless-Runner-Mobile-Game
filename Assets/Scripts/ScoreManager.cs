using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    // public variables and floats to define the high score system
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    // Points per second as the player is in the level
    public float pointsPerSecond;

    // Determine if the score should still be increasing
    public bool scoreIncreasing;

    // Public bool to determine if it should double coin amount
    public bool shouldDouble;


    // Start is called before the first frame update
    void Start()
    {
        // Get the last high score and set it to the new high score everytime the game is loaded
        if (PlayerPrefs.HasKey("HighScore")) 
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Score count will increase if the score increasing is true
        if (scoreIncreasing)
        {
            // Add Score onto the score count as the game goes on  
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        // Set high score if the score count tries to go above it, save high score
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }


        // As counter increases add a score onto the score text which is a rounded number
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "HighScore: " + Mathf.Round(hiScoreCount); 

    }

    // Public value that takes in a whole number to add to the score
    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            pointsToAdd = pointsToAdd * 2;
        }
        scoreCount += pointsToAdd;
    }

}
