using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathZoneBox : MonoBehaviour
{
    public GameManage gameManager;
    public PlayerMovement playerMovement;
    public SpriteRenderer playerSprite;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.gameOver();
            playerSprite.enabled = false;
            playerMovement.enabled = false;
            Debug.Log("Dead");
        }
    }
    
       
}
