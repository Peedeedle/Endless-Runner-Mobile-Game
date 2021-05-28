using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    // public variables for the length the powerups last and what they are called
    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;

    private PowerupManager thePowerupManager;

    public Sprite[] powerupSprites;

    // Start is called before the first frame update
    void Start()
    {
        thePowerupManager = FindObjectOfType<PowerupManager>();
    }

    // When game is playing, decide a random range between 0 and 1 and select which piece of code to run per powerup
    private void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            //case 0: safeMode = true;
                //break;
            case 1: doublePoints = true;
                break;
        }

        //
        //GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];

    }

    // On trigger activate powerup depending on which powerup has been recieved
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            thePowerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
        }

        gameObject.SetActive(false);
    }

}
