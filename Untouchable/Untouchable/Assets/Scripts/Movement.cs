﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject meterHolder;
    public GameObject MainCamera;
    public GameObject InvinciblePanel;
    public PauseMenuBehavior Pause;

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    private bool canResetJump = true;

    // Forces that involves the player.
    public float jumpForce;
    public float gravForce;
    public float dashSpeed;
    public float iAmSpeed;
    public float waitTime = 4.25f;
    public bool grounded;
    public bool didDash;
    public bool canMove;

    public float meter;

    private IEnumerator DashState;
    private float fixedDeltaTime;
    public AudioClip untouchableSound;

    [Header("Jump audio settings")]
    public AudioClip landingSound;
    public AudioClip landingSound2;
    public AudioClip landingSound3;

    private List<AudioClip> landingSoundsList = new List<AudioClip>();

    [Header("Bash audio settings")]
    public AudioClip bashSound;
    public AudioClip bashSound2;
    public AudioClip bashSound3;
    private List<AudioClip> bashSoundsList = new List<AudioClip>();

    
    // Start is called before the first frame update
    void Start()
    {
        // Sets the player as grounded so they are allowed to jump.
        grounded = true;

        didDash = true;

        iAmSpeed = 1;

        meter = 0;
        
        StartCoroutine(WaitToRun());

        

        

        // Players rigidbody. Yep.
        rb = GetComponent<Rigidbody>();

        // Landing sounds
        landingSoundsList.Add(landingSound);
        landingSoundsList.Add(landingSound2);
        landingSoundsList.Add(landingSound3);

        // Add bash sound effects
        bashSoundsList.Add(bashSound);
        bashSoundsList.Add(bashSound2);
        bashSoundsList.Add(bashSound3);
    }

    // Update is called once per frame
    void Update()
    {
        // Updates when the Player is on the horizontal/vertical axis.
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Function that allows player to jump.
        Jump();

        DashMeter();

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            // Allows the player to move forward and backwards.
            ForwardMovement = transform.forward * 1;

            // Allows the player to move left and right.
            RightMovement = transform.right * horizInput;

            // Allows the player to move around, and the speed at which they are allowd to move.
            velocity = (RightMovement + ForwardMovement).normalized * speed * iAmSpeed;

            // Moves the rigidbody towards a position.
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        // Function that adds "weight" to the player when they are coming back down.
        Gravity();

    }

    private IEnumerator WaitToRun()
    {
        yield return new WaitForSeconds(MainCamera.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length + 1);
        canMove = true;
    }

    void Jump()
    {
        // Adds a force when the player presses space, and they are on the platform.
        if (Input.GetKeyDown("space") && grounded == true)
        {
            StartCoroutine(AllowJumpReset());
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            grounded = false;
        }
    }

    private IEnumerator AllowJumpReset()
    {
        canResetJump = false;
        yield return new WaitForSeconds(0.2f);
        canResetJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with the platform, they are allowed to jump again.
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (canResetJump)
            {
                grounded = true;
            }
            StartCoroutine(PlaySound(landingSoundsList));
        }

        // If player collides with the platform, they are allowed to jump again.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(PlaySound(bashSoundsList));
        }

        if(collision.gameObject.CompareTag("ResetVelocity"))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NearMiss"))
        {
            meter += 10;
            meter = Mathf.Clamp(meter, 0, 100);
            meterHolder.GetComponent<DashBar>().barImage.fillAmount += .1f;
        }
        if(other.gameObject.CompareTag("ResetVelocity"))
        {
            rb.velocity = Vector3.zero;
        }

    }

    void Gravity()
    {
        // When the player is in the air, it adds a downward force to add "weight" to the player.
        if (grounded == false)
        {
            rb.AddForce(0, -gravForce, 0, ForceMode.Impulse);
        }
    }

    void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Invincible());
            GetComponent<AudioSource>().PlayOneShot(untouchableSound, 1);
            //rb.AddForce(0, 0, dashSpeed, ForceMode.Impulse);
            meter = 0;
            meterHolder.GetComponent<DashBar>().barImage.fillAmount = 0;
            InvinciblePanel.SetActive(true);
            StartCoroutine(UpdateTimerUI());
        }
      
    }

    void DashMeter()
    {
        if(meter < 100)
        {
            //do nothing
        }
        else if(meter == 100)
        {
            Dashing();
        }
    }


    IEnumerator PlaySound(List<AudioClip> soundList)
    {
        AudioSource.PlayClipAtPoint(soundList[Random.Range(0, soundList.Count)], transform.position);
        yield break;
    }

    IEnumerator Invincible()
    {
        gameObject.layer = 10;

        yield return new WaitForSeconds(waitTime);
        InvinciblePanel.SetActive(false);

        gameObject.layer = 9;
    }
    
    //call this on update
    public IEnumerator UpdateTimerUI()
    {        
        //set timer UI
        secondsCount = waitTime;

        for (int i = 0; i < waitTime; i++)
        {
            timerText.text = "Invincible for " + (int)secondsCount + "s";
            yield return new WaitForSeconds(1);
            secondsCount--;
        }
    }

}
