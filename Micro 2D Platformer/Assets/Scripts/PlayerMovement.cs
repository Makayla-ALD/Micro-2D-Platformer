using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //how fast the player can move
    public float jumpForce; // how high the player can jump
    private Rigidbody2D playerBody;
    bool isJumping;
    bool isSprinting;

    //Buffs and Nerfs
    float speedMultiplyer = 1f;
    float speedDecrease = 2f;

    //Player Knockback
    public float KnockbackForce;
    public float KnockbackTime;
    public float KnockbackDuration;
    public bool KnockbackHappened;


    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>(); //Needs to access player object's rigidbody
    }

    
    private void Start()
    {
        SpeedBoost.OnSpeedCollected += StartSpeedBoost;

        SpeedNerf.OnSpeedNerfCollected += StartSpeedNerf;
    }

    void StartSpeedBoost(float multiplyer)
    {
        if (this != null) // Check if the player object still exists before starting the coroutine
            StartCoroutine(SpeedBoostCoroutine(multiplyer));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplyer = multiplier;
        yield return new WaitForSeconds(3f);//how long the boost lasts
        Debug.Log("Boost done");
        speedMultiplyer = 1f;
    } 

    void StartSpeedNerf(float divider)
    {
        if (this != null) // Check if the player object still exists before starting the coroutine
            StartCoroutine(SpeedNerfCoroutine(divider));
    }

    private IEnumerator SpeedNerfCoroutine(float divider)
    {
        speedDecrease = divider;
        yield return new WaitForSeconds(2f); //how long the nerf lasts
        Debug.Log("Nerf done");
        speedDecrease = 2f;
    }

   
    void Update()
    {
        
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * speedMultiplyer / speedDecrease, playerBody.velocity.y); // player horizontal movement

        if (Input.GetKey(KeyCode.W) && !isJumping) // player jump, only if player is not already jumping
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            isJumping = true;
            Debug.Log("Jump!");
        }
        
    }

    void FixedUpdate()
    {
        if(KnockbackTime <= 0)
        {
            playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * speedMultiplyer / speedDecrease, playerBody.velocity.y);
        }
        else
        {
            if(KnockbackHappened == true)
            {
                playerBody.velocity = new Vector2(-KnockbackForce, KnockbackForce);
            }
            if(KnockbackHappened == false)
            {
                playerBody.velocity = new Vector2(KnockbackForce, KnockbackForce);
            }
            KnockbackTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
