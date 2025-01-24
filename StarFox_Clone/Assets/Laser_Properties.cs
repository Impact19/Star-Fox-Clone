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
   



    // Start is called before the first frame update
    void Start()
    {
        laserRB = GetComponent<Rigidbody>(); 

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        laserMovement();
    }

    private void laserMovement() {

        laserRB.velocity = ship.transform.forward * laserSpeed;
    }
}
