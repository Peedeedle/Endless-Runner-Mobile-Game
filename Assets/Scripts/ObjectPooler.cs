using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{

    // create a list of pooled objects
    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        // Create new list of pooled objects e.g. platforms
        pooledObjects = new List<GameObject>();

        // Instantiate pooled object and add to the list
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            
            obj.SetActive(false);
            pooledObjects.Add(obj); 
        }
    }

    // Search list to find and object that is not active
    public GameObject GetPooledObject()
    {
        // If pooled objects in list is active return pooled objects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                
                return pooledObjects[i];
            }
        }

        // Return inactive object
        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;

    }

}
