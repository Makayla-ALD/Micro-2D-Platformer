using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 1;
    public PlayerMovement playerMovement;
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.KnockbackTime = playerMovement.KnockbackDuration;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockbackHappened = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockbackHappened = false;
            }


            playerHealth.TakeDamage(damage);
            Debug.Log("Attack!");
        }
    }
}
