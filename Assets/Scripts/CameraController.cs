using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Find what the player is
    public PlayerController thePlayer;

    // Find position of player
    private Vector3 lastPlayerPosition;

    // 
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // set the distance needed to move the camera along the x Axis
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        // transform the position of the camera to follow the Axis of the player
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        // Last player position = the position of the player
        lastPlayerPosition = thePlayer.transform.position;
    }
}
