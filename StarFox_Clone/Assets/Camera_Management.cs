using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Management : MonoBehaviour
{

    [SerializeField] private Ship_Rail_Movement railMovement;
    private Rigidbody cameraRB;
    [SerializeField] private Vector3 distanceFromShip;
    [SerializeField] private GameObject ship;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;  
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        cameraRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        

      // cameraRB.position =  Vector3.MoveTowards(cameraRB.position, ship.transform.position - distanceFromShip, Time.deltaTime * railMovement.getShipRailSpeed() );
        transform.position = Vector3.SmoothDamp(transform.position, ship.transform.position, ref velocity, smoothTime);
    } 


}
