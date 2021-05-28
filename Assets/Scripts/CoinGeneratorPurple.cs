using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorPurple : MonoBehaviour
{
    // Public coin pooler
    public ObjectPooler coinPool;

    // Public float for the distance between coins
    public float distanceBetweenCoins;

   // Set position of coin and set to active
   public void SpawnCoins (Vector3 startPosition)
    {
        // Get the pooled object and the positions of the coins
        GameObject coin4 = coinPool.GetPooledObject();
        coin4.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y + 2f, startPosition.z);
        coin4.SetActive(true);
    }

}
