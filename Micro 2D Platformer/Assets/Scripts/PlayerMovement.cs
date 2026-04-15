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
    public float KnockbackForce;
    public float KnockbackTime;
    public float KnockbackDuration;
    public bool KnockbackHappened;


    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>(); //Needs to access player object's rigidbody
    }

    
    void Start()
    {
        SpeedBoost.OnSpeedCollected += StartSpeedBoost;

        SpeedNerf.OnSpeedNerfCollected += StartSpeedNerf;
    }

    void StartSpeedBoost(float multiplyer)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplyer));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplyer = multiplier;
        yield return new WaitForSeconds(3f);
        Debug.Log("Boost done");
        speedMultiplyer = 1f;
    } 

    void StartSpeedNerf(float divider)
    {
        StartCoroutine(SpeedNerfCoroutine(divider));
    }

    private IEnumerator SpeedNerfCoroutine(float divider)
    {
        speedDecrease = divider;
        yield return new WaitForSeconds(2f);
        Debug.Log("Nerf done");
        speedDecrease = 2f;
    }

   
    void Update()
    {
        
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * speedMultiplyer / speedDecrease, playerBody.velocity.y); // player horizontal movement

        if (Input.GetKey(KeyCode.Space) && !isJumping)
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
