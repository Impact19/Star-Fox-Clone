using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Properties : MonoBehaviour
{ 
   [SerializeField] private float laserDamage;
   [SerializeField] private float laserSpeed;
   [SerializeField] private Vector3 laserDirection;
   [SerializeField] private Rigidbody laserRB;
   [SerializeField] private Rigidbody ship;
   [SerializeField] private float spawnTime;
    private float ogSpawnTime;
    private Enemy_Behavior hitEnemy; 


    // Start is called before the first frame update
    void Start()
    {
        laserRB = GetComponent<Rigidbody>();
        ogSpawnTime = spawnTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            laserLifeTime(); 
        }
    }

    private void FixedUpdate()
    {
        laserMovement();
    }

    private void laserMovement() {

        laserRB.velocity = new Vector3(0, 0, laserSpeed); 
    }

    private void removeLaser() {
          gameObject.SetActive(false);
          spawnTime = ogSpawnTime; 
    }

    private void OnCollisionEnter(Collision collision)
    { 
       
        hitEnemy = collision.gameObject.GetComponent<Enemy_Behavior>();
        hitEnemy.OnDamage(laserDamage); 


    }

    private void laserLifeTime() {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            removeLaser(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy_Behavior>() != null)
        {
            hitEnemy = other.gameObject.GetComponent<Enemy_Behavior>();
            hitEnemy.OnDamage(laserDamage);
        }
        removeLaser();
        
    }
}

