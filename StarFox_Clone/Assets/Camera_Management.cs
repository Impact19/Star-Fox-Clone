using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Management : MonoBehaviour
{

    [SerializeField] private Ship_Movement shipMovement;
    private Rigidbody cameraRB;
    [SerializeField] private float distanceFromShip;
    void Start()
    {
        cameraRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraRB.velocity = new Vector3(0, 0, shipMovement.getShipRailSpeed()); 
    } 


}
