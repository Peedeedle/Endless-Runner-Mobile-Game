using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    // Public list for spawn points
    public Transform[] spawnPoints;

    // Reference to game object needed to spawn in
    public GameObject rockPrefab;

    // Time to spawn = 2 seconds
    private float timeToSpawn = 10f;

    // Time between spawn waves
    public float timeBetweenWaves = 10f;

    // Update is called once per frame
    void Update()
    {
        // If time is >= time to spawn then spawn rocks
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves; 
        }

        
    }




    // Start is called before the first frame update
    void SpawnBlocks()
    {
        // Choose random spawn for the rocks in the list of spawn points
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // For loop to incrememnt i each time from 1 - spawn points length until you reach all of them, however half the length and decide to spawn half of the whole length in rocks
        for (int i = 0; i < spawnPoints.Length - spawnPoints.Length / 2; i++)
        {
            // If random index = i instantiate the rock at the spawn points position with no rotation
            if (randomIndex != i)
            {
                Instantiate(rockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }

    }







}  



