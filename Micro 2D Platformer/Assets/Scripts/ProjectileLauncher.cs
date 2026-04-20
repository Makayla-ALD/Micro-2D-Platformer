using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public ProjectilePooler projectilePooler;

    public float shootTime; //cooldown between projectiles
    public float shootCounter; //cooldown timer
    
    
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && shootCounter <= 0)
        {
            GameObject projectile = projectilePooler.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = launchPoint.position;
                projectile.SetActive(true);
            }
            //Instantiate(projectilePrefab, launchPoint.position, Quaternion .identity);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}
