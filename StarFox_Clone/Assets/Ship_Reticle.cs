using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Reticle : MonoBehaviour
{
    
    

    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform shipTurret;
    [SerializeField] private Camera camera;
    [SerializeField] private float offset; 

    void Start()
    {

        crosshair = GetComponent<RectTransform>();  

    }

    // Update is called once per frame
    void Update()
    {
        aimCrossHair(); 

    }

    private void LateUpdate()
    {
       
        
    }

    private void aimCrossHair() {
        Vector3 worldPos = shipTurret.position + shipTurret.forward * offset;

        Vector3 screenPos = camera.WorldToScreenPoint(worldPos);

        crosshair.position = screenPos;

    }
}
