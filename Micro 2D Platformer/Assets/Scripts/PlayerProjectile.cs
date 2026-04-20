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
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var projCol = GetComponent<Collider2D>();
            if (projCol != null)
            {
                foreach (var pc in player.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(pc, projCol);
                }
            }
        }
    }

    void OnEnable()
    {
        // Reset lifetime every time the projectile becomes active 
        projectileCount = projectileLife;

        // Give an initial velocity immediately when enabled 
        if (projectileRb != null)
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (projectileRb != null)
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        gameObject.SetActive(false);
    }
}
