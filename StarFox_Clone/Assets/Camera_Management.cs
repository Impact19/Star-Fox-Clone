using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Management : MonoBehaviour
{

    [SerializeField] private Ship_Rail_Movement railMovement;
    private Rigidbody cameraRB;
    [SerializeField] private float maxShipDistanceZ;
    [SerializeField] private GameObject ship;
    [SerializeField] private float offset;
    [SerializeField] private float smoothTime;  
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Vector3 startingPosition; 
    
    void Start()
    {
        cameraRB = GetComponent<Rigidbody>();
        startingPosition = transform.position ;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float shipDistanceZ = Vector3.Distance(ship.transform.position, transform.position);

        
      //  cameraRB.velocity = new Vector3(0f, 0f, railMovement.getShipRailSpeed() );
        transform.position = new Vector3(startingPosition.x, startingPosition.y, ship.transform.position.z - offset); 
    } 


}
