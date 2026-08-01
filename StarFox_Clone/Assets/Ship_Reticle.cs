using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Reticle : MonoBehaviour
{
    [SerializeField] private Transform shipTurret;
    [SerializeField] private Camera camera;
    private Transform reticle;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float num; 
    // Start is called before the first frame update
    void Start()
    {
        reticle = GetComponent<Transform>(); 
       
    }

    // Update is called once per frame
    void Update()
    {
      //  reticle.position = Vector3.Normalize( camera.WorldToScreenPoint(shipTurret.position) ); 
    }

    private void LateUpdate()
    {
        offset = new Vector3(num, num, 0); 
        reticle.position = camera.WorldToScreenPoint(shipTurret.position) + offset;
        
    }
}
