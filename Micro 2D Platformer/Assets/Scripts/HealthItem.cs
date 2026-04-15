using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, InterfaceItem
{
    public int healingAmount = 1;
    public static event Action<int> OnHealthCollected;

    public void Collect()
    {
       OnHealthCollected.Invoke(healingAmount);
       Destroy(gameObject);
       Debug.Log("Heal taken!");
    }
}
