using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedNerf : MonoBehaviour, InterfaceItem
{
    public static event Action<float> OnSpeedNerfCollected;
    public float speedLowered = 2f;

    public void Collect()
    {

        OnSpeedNerfCollected.Invoke(speedLowered);
        Destroy(gameObject);
        Debug.Log("Speed nerf collected!");
    }

}
