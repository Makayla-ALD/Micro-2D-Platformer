using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    public Image[] healthIcon; //image array for health icon
    public Sprite emptyIcon;
    public Sprite fullIcon;

    public int health;
    public int maxHealth;

    public PlayerHealth playerHealth;

   public void Update()
    {
        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;
        
        for (int i = 0; i < healthIcon.Length; i++)
        {
            if(i < health) //checks each heart to see if it should be full or empty
            {
                healthIcon[i].sprite = fullIcon;
            }
            else
            {
                healthIcon[i].sprite = emptyIcon;
            }

            if (i < maxHealth)
            {
                healthIcon[i].enabled = true;
            }
            else
            {
                healthIcon[i].enabled = false;
            }
        }
    }

}
