using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Properties : MonoBehaviour
{ 
   [SerializeField] private float damage;
   [SerializeField] private float laserSpeed;
   [SerializeField] private Vector3 laserDirection;
   [SerializeField] private Rigidbody laserRB;
   [SerializeField] private Rigidbody ship;
   [SerializeField] private float spawnTime;
    private float ogSpawnTime; 



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
            removeLaser();
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
         
     spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                gameObject.SetActive(false);
                spawnTime = ogSpawnTime; 
            }
        }
       
    }

