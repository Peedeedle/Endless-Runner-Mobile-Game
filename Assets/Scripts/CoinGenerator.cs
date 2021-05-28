using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // Public coin pooler
    public ObjectPooler coinPool;

    // Public float for the distance between coins
    public float distanceBetweenCoins;

   // Set position of coin and set to active
   public void SpawnCoins (Vector3 startPosition)
    {
        // Coin spawns in the middle
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        // Coin spawns to the left 
        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
        coin2.SetActive(true);

        // Coin spawns to the right
        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }

}
