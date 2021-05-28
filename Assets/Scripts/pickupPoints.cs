using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour
{
    // Whole number value to give player
    public int scoreToGive;

    // Private reference to the score manager
    private ScoreManager theScoreManager;

    // Find Score manager object
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // 
    void Update()
    {
        
    }

    // Check when the player walks into the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the coin, if so deactivate the coin to be initialized later
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }

    }

}
