using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winUI;

    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winUI.SetActive(true);
            playerMovement.enabled = false;
            Debug.Log("You win!");  
        }
    }
    
}
