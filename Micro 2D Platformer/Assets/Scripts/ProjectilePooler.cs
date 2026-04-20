using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ProjectilePooler : MonoBehaviour
{
    public static ObjectPool<GameObject> instance;
    private List<GameObject> poolObj = new List<GameObject>();
    private int numToPool = 20;

    [SerializeField] private GameObject projectilePrefab;
    void Start()
    {
        for (int i = 0; i < numToPool; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            poolObj.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObj.Count; i++)
        {
            if (!poolObj[i].activeInHierarchy)
            {
                return poolObj[i];
            }
        }

        return null;
    }
}
