using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InterfaceItem item = collision.GetComponent<InterfaceItem>();
        if(item != null )
        {
            item.Collect();
        }
    }
}
