using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variables for how the character moves.
    public float speed;
    private float horizInput;
    private float vertInput;
    private Vector3 ForwardMovement;
    private Vector3 RightMovement;
    private Rigidbody rb;
    private Vector3 velocity;

    // Forces that involves the player.
    public float jumpForce;
    public float gravForce;
    public float dashSpeed;
    public bool grounded;
    public bool didDash;

    private float meter;

    
    // Start is called before the first frame update
    void Start()
    {
        // Sets the player as grounded so they are allowed to jump.
        grounded = true;

        didDash = false;

        // Players rigidbody. Yep.
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Updates when the Player is on the horizontal/vertical axis.
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Function that allows player to jump.
        Jump();

        // Function that adds "weight" to the player when they are coming back down.
        Gravity();

        Dashing();

        DashMeter();
    }

    private void FixedUpdate()
    {
        // Allows the player to move forward and backwards.
        ForwardMovement = transform.forward * vertInput;

        // Allows the player to move left and right.
        RightMovement = transform.right * horizInput;

        // Allows the player to move around, and the speed at which they are allowd to move.
        velocity = (RightMovement + ForwardMovement).normalized * speed;

        // Moves the rigidbody towards a position.
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        
    }

    void Jump()
    {
        // Adds a force when the player presses space, and they are on the platform.
        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with the platform, they are allowed to jump again.
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NearMiss"))
        {
            meter += 10;
            Debug.Log(meter);
        }
    }

    void Gravity()
    {
        // When the player is in the air, it adds a downward force to add "weight" to the player.
        if(grounded == false)
        {
            rb.AddForce(0, -gravForce, 0, ForceMode.Impulse);
        }
    }

    void Dashing()
    {
        if (Input.GetMouseButtonDown(0) && didDash == false)
        {
            rb.AddForce(0, 0, dashSpeed, ForceMode.Impulse);
            meter = 0;
        }
    }

    void DashMeter()
    {
        if(meter < 100)
        {
            didDash = true;
        }
        else if(meter == 100)
        {
            didDash = false;
        }
            
    }
        

}
