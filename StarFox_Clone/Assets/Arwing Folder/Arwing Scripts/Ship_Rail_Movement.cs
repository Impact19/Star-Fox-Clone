using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
public class Ship_Rail_Movement : MonoBehaviour
{
    [SerializeField] private Game_Input gameInput; 
    
    [SerializeField] private float currentRailSpeed;
    [SerializeField] private float normRailSpeed;
    [SerializeField] private float maxRailSpeed;
    [SerializeField] private float minRailSpeed;
    [SerializeField] private float speedIncrement; 
     
    [SerializeField] private float accelMeter;
    [SerializeField] private float accelIncrement; 
    [SerializeField] private float maxAccelMeter;
     
    private enum speedState { normal, boost, brake, refillMeter }; 
    
 
    [SerializeField] private speedState currentSpeedState;
   
    // Start is called before the first frame update
    void Start()
    { 

        currentRailSpeed = normRailSpeed;
        currentSpeedState = speedState.normal; 
        accelMeter = maxAccelMeter;  
        
    }
    private void Awake()
    {
        gameInput = new Game_Input();

    }
    // Update is called once per frame
    void Update()
    {
        // shipRailMovement();
       //
       //
       //
       //
       //
      shipMoveResource();
      
    }

    public float getShipRailSpeed()
    {
        return currentRailSpeed; 
    }

    
    private void shipMoveResource() {
       accelMeter =  Mathf.Clamp(accelMeter, 0, maxAccelMeter);
        if (currentSpeedState == speedState.boost)
        {
            decreaseMeter(); 
            if(currentRailSpeed <= maxRailSpeed) currentRailSpeed += speedIncrement;
        }
        else if (currentSpeedState == speedState.brake)
        {
            decreaseMeter();
          if(currentRailSpeed >= minRailSpeed)  currentRailSpeed -= speedIncrement;
        }
        else if (currentSpeedState == speedState.normal) {
            if (!isMeterFull()) increaseMeter();
            currentRailSpeed = normRailSpeed; 
        }
        

    }

 

    private void increaseMeter() {
        accelMeter += accelIncrement;
    }

    private void decreaseMeter() {
        if (accelMeter >= 0) accelMeter -= accelIncrement;
        else currentSpeedState = speedState.normal; 
    }

    
    private bool isMeterFull() {
        Debug.Log("Meter is Full"); 
        return accelMeter >= maxAccelMeter; 
    }

    private void boostShip() {
        if (isMeterFull()) {
            currentSpeedState = speedState.boost;
        
        }
    }

    private void brakeShip() {
        if (isMeterFull()) {
            currentSpeedState = speedState.brake;
        }
    
    }

    private void normalShip() {
        currentSpeedState = speedState.normal;
        if (!isMeterFull()) increaseMeter(); 
    }
        private void OnEnable()
        {
            gameInput.Ship.Boost.performed += ctx => boostShip() ;
            gameInput.Ship.Boost.canceled += ctx => normalShip();
            gameInput.Ship.Brake.performed += ctx => brakeShip();
            gameInput.Ship.Brake.canceled += ctx => normalShip();

            gameInput.Ship.Boost.Enable();
            gameInput.Ship.Brake.Enable();
        }

        private void OnDisable()
        {
            gameInput.Ship.Boost.performed -= ctx => boostShip(); 
            gameInput.Ship.Boost.canceled -= ctx => normalShip();
            gameInput.Ship.Brake.performed -= ctx => brakeShip();
            gameInput.Ship.Brake.canceled -= ctx => normalShip();

            gameInput.Ship.Boost.Disable();
            gameInput.Ship.Brake.Disable();
        }

   
}
