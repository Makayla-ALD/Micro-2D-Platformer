using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife; //how long it lasts
    public float projectileCount; //the count down till the projectile is destroyed

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife; //starts as soon as projectile is spwaned

        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;  
        if(projectileCount <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
