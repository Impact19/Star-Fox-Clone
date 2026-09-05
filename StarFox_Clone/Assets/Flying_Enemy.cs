using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Enemy : Enemy_Behavior
{
    [Header("Flying Enemy Variables")]

    [SerializeField] private float flySpeed;
    [SerializeField] private float fireRate,ogFireRate;
    [SerializeField] private GameObject turret;
    [SerializeField] private Vector3 offset; 
    private Rigidbody rig;
    private Laser_Pool laserPool;

    // Start is called before the first frame update
   private void Start()
    {
        base.Start(); 
        laserPool = GetComponent<Laser_Pool>();
        laserPool.spawnLaserPool();
        rig = GetComponent<Rigidbody>();
        ogFireRate = fireRate; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {
            fireLaser(); 
        }
      rig.velocity = new Vector3(0, 0, flySpeed); 
    }

    
    private void fireLaser() { 
        
        ogFireRate -= Time.deltaTime;
        if (ogFireRate <= 0) {

            laserPool.getLaser().SetActive(true);
            laserPool.getLaser().transform.position = turret.transform.position + offset;
            ogFireRate = fireRate; 
        }
    }
}
