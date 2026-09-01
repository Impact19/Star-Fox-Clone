using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Pool : MonoBehaviour
{
    public GameObject laserObject;
    public GameObject[] laserPool;
    public int laserAmount; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getLaser()
    {

        for (int x = 0; x < laserPool.Length; x++)
        {
            if (!laserPool[x].activeSelf)
            {
                laserPool[x].SetActive(true);
                return laserPool[x];
            }
        }
        return null;

    }

    public void spawnLaserPool()
    {
        laserPool = new GameObject[laserAmount];
        for (int x = 0; x < laserAmount; x++)
        {
            if (laserPool[x] != null) Destroy(laserPool[x]);
            laserPool[x] = Instantiate(laserObject);
            laserPool[x].SetActive(false);
        }
    }

    public void deleteLaserPool()
    {
        for (int x = 0; x < laserAmount; x++)
        {
            Destroy(laserPool[x]);
        }
    }
}
