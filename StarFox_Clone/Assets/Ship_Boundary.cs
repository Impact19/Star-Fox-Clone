using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Boundary : MonoBehaviour
{
    [SerializeField] private Ship_Rail_Movement shipRail;
    [SerializeField] Rigidbody boundRB; 
    void Start()
    {
        boundRB = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        boundRB.velocity =  new Vector3(0,0, shipRail.getShipRailSpeed() ); 
    }
}
