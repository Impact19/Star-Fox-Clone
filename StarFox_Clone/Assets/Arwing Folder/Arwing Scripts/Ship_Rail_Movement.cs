using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Rail_Movement : MonoBehaviour
{
    [SerializeField] private Game_Input gameInput; 
    
    [SerializeField] private float currentRailSpeed;
    [SerializeField] private float normRailSpeed;
    [SerializeField] private float maxRailSpeed;
    [SerializeField] private float minRailSpeed;
    [SerializeField] private float boostAccel;
    [SerializeField] private float brakeAccel;

    [SerializeField] private float accelMeter;
    [SerializeField] private float accelIncrement; 
    [SerializeField] private float maxAccelMeter; 
    private enum speedState { normal, boost, brake };
    [SerializeField] private speedState currentSpeedState;

    // Start is called before the first frame update
    void Start()
    {
        currentRailSpeed = normRailSpeed;
        currentSpeedState = speedState.normal;
    }
    private void Awake()
    {
        gameInput = new Game_Input();

    }
    // Update is called once per frame
    void Update()
    {
        shipRailMovement();
    }

    public float getShipRailSpeed()
    {
        return currentRailSpeed;
    }

    private void shipRailMovement()
    {
        if (currentSpeedState == speedState.normal)
        {
            currentRailSpeed = normRailSpeed;
            increaseMeter(); 
        }
      else if(accelMeter >= 0)
        {
            if (currentSpeedState == speedState.boost)
            {
                currentRailSpeed = maxRailSpeed;
                decreaseMeter();
            }
            else if (currentSpeedState == speedState.brake)
            {
                currentRailSpeed = minRailSpeed;
                decreaseMeter();
            }

        }
            
        
    }

    private bool canAccel() {
        if (currentSpeedState != speedState.normal && accelMeter >= maxAccelMeter)
            return true;
        else
            return false; 
    }

    private void increaseMeter() {
        if (accelMeter <= maxAccelMeter) accelMeter += accelIncrement; 
    }

    private void decreaseMeter() {
        if (accelMeter >= 0) accelMeter -= accelIncrement; 
    }

    private void OnEnable()
    {
        gameInput.Ship.Boost.performed += ctx => currentSpeedState = speedState.boost;
        gameInput.Ship.Boost.canceled += ctx => currentSpeedState = speedState.normal;
        gameInput.Ship.Brake.performed += ctx => currentSpeedState = speedState.brake;
        gameInput.Ship.Brake.canceled += ctx => currentSpeedState = speedState.normal;

        gameInput.Ship.Boost.Enable();
        gameInput.Ship.Brake.Enable();
    }

    private void OnDisable()
    {
        gameInput.Ship.Boost.performed -= ctx => currentSpeedState = speedState.boost;
        gameInput.Ship.Boost.canceled -= ctx => currentSpeedState = speedState.normal;
        gameInput.Ship.Brake.performed -= ctx => currentSpeedState = speedState.brake;
        gameInput.Ship.Brake.canceled -= ctx => currentSpeedState = speedState.normal;

        gameInput.Ship.Boost.Disable();
        gameInput.Ship.Brake.Disable();
    }
}
