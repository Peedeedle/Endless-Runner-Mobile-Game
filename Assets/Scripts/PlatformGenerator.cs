using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    // generation, platforms and distancing
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    // Avoid overlapping platforms
    private float platformWidth;

    // public platform distance floats to vary platform distance to add randomness
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    // Platform array
    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    // Object pool object
    public ObjectPooler[] theObjectPools;

    // Private values for height 
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    // Private coin generator
    private CoinGenerator theCoinGenerator;

    // Random number to decide how far away the other coins are to decide whether to spawn more coins
    public float randomCoinThreshold;

    // If it generates a specific number then create rocks anywhere along the platform
    public float randomRockThreshold;
    public ObjectPooler PurpleCoinPool;

    // Powerup variables
    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;


    // Start is called before the first frame update 
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        //  Array of platform widths
        platformWidths = new float[theObjectPools.Length];

        // Set the size of the platforms to the individual platforms
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        // max and min height = Y positions
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        // Find coin generator object and script
        theCoinGenerator = FindObjectOfType<CoinGenerator>();

    }




    // Update is called once per frame
    void Update()
    {
        // Create platform within distance of the old platform 
        if (transform.position.x < generationPoint.position.x)
        {
            // pick random range between the minimum and maximum platform distance
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // Select a random platform in the range of different platforms
            platformSelector = Random.Range(0, theObjectPools.Length);

            // set height change to randomly place a platform within the height
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            // If the height is too high or too low set to the lowest and highest height
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            // Decide to randomly generate powerup
            if(Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range (powerupHeight, powerupHeight), 0f);

                newPowerup.SetActive(true);
            }




            // Move platform generator ahead so the platforms do not collide, move platform half along then generate another platform
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            // Create the platform
            //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);

            // Create new platform object which is = pooled object
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            // set position to platform width etc and set to true
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            // If number generated is less than random coin threshold then run this code
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                // Spawn the coins from the generator above the platform
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            // If number generated is less than random rock threshold then run this code
            if (Random.Range(0f, 100f) < randomRockThreshold)
            {
                // Go into rock pool and get new object that isnt being used
                GameObject newRock = PurpleCoinPool.GetPooledObject();

                //
                float rockXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f + -1f);




                // Set rock position to be above the platform
                Vector3 rockPosition = new Vector3(rockXPosition, 3f, 0f);





                // Set position and rotation and set the game object to true so it is visible
                newRock.transform.position = transform.position + rockPosition;
                newRock.transform.rotation = transform.rotation;
                newRock.SetActive(true);

            }




                // Move platform generator ahead so the platforms do not collide, move platform half along then generate another platform
                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }

    }
}
