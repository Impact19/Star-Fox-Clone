using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Management : MonoBehaviour
{

    [SerializeField] private Ship_Rail_Movement railMovement;
    private Rigidbody cameraRB;
    [SerializeField] private Vector3 distanceFromShip;
    [SerializeField] private GameObject ship; 
    void Start()
    {
        cameraRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

       cameraRB.position =  Vector3.MoveTowards(cameraRB.position, ship.transform.position - distanceFromShip, Time.deltaTime * railMovement.getShipRailSpeed() );

    } 


}
