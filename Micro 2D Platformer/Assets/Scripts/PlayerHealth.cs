using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth; //player's current health
    public int maxHealth = 3; //how much health the player can have

    public SpriteRenderer playerSprite;
    public PlayerMovement playerMovement;

    public HealthUi healthUi;
    public GameManage gameManager;
    
    void Start()
    {
        currentHealth = maxHealth;
        HealthItem.OnHealthCollected += Heal;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth) //keeps current health from going over max health 
        {
            currentHealth = maxHealth;
        }

        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // player's health will subtract by the damage amount set for enemy
        if(currentHealth <= 0) // if health drpos to 0, player is destroyed, aka sprite and movement disabled
        {
            playerSprite.enabled = false;
            Time.timeScale = 0f;
            gameManager.gameOver();

        }
    }
}
