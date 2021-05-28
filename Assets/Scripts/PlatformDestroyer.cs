using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    // platform variable
    public GameObject platformDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // If the platfrom is less than the destruction position destroy the platform
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);


            // Set game object to false
            gameObject.SetActive(false);
        }
    }
}
