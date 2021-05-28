using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public AudioSource MinecartMoving;


    // Speed jump and speed value and speed stored
    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;
    public float speedMultiplier;

    // When a player reaches a certain distance increase the speed of the player
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    // Distance when the player reaches increase player speed
    private float speedMilestoneCount;

    // Stored speed milstone count
    private float speedMilestoneCountStore;

    // Create variable for the time the player is able to jump for
    public float jumpTime;
    private float jumpTimeCounter;

    // True when touched ground, false when jumping
    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidBody;

    // bool to check if the player is grounded or not
    public bool grounded;

    // Selection of layer set as "whatIsGround"
    public LayerMask whatIsGround;

    // Better detection for grounded
    public Transform groundCheck;
    public float groundCheckRadius;

    // Set collider to my collider
    //private Collider2D myCollider;

    // Private animator
    private Animator myAnimator;

    // Reference to gamemanager
    public GameManager theGameManager;




    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody componect to the player
        myRigidBody = GetComponent<Rigidbody2D>();

        // Search player to find collider
        //myCollider = GetComponent<Collider2D>();

        // Get animator component
        myAnimator = GetComponent<Animator>();

        // jump time counter is equal to jump time
        jumpTimeCounter = jumpTime;

        // Set speed milestone count to the first milestone instead of at the start of the game
        speedMilestoneCount = speedIncreaseMilestone;

        // When the game restarts, reset player speed and milestone count
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
        
    }




    // Update is called once per frame
    void Update()
    {

        // check to see if bool is true or false
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        // Determine when the player is on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // If the player is further than the milestone counter increase player speed and milestone distance
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        // Set velocity to the move speed and not affect the Y axis
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        // if spacebar or left mouse button is pressed make the player jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) 
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;


                


            }

            // If player is not grounded and canDoubleJump is true allow double jump then set back to false
            if (!grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

                stoppedJumping = false;
                canDoubleJump = false;

                

            }
            
        }

        // When the player jumps the timer counts down to stop the player continuously jumping
        if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

                

            }
        }

        // When jump button is released the player is able to jump again once the timer reaches 0
        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        // If the player is grounded allow the player to jump at any height again
        if (grounded)
        {
            

            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        // Assign speed value to animator
        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);

        // Assign grounded trait
        myAnimator.SetBool("Grounded", grounded);

    }

    // When player collides with "killBox" execute restart game and reset players speed and milestone count
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killBox")
        {
            
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

}
