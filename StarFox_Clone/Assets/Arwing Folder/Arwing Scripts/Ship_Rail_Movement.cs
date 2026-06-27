using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
public class Ship_Rail_Movement : MonoBehaviour
{
    [SerializeField] private Game_Inputs gameInput; 
    
    [SerializeField] private float currentRailSpeed;
    [SerializeField] private float normRailSpeed;
    [SerializeField] private float maxRailSpeed;
    [SerializeField] private float minRailSpeed;
    [SerializeField] private float speedIncrement; 
     
    [SerializeField] public float accelMeter;
    [SerializeField] private float accelIncrement; 
    [SerializeField] public float maxAccelMeter;
     
    private enum meterState {full, inUse, empty  }; 
    
 
    [SerializeField] private meterState currentmeterState;
   
    // Start is called before the first frame update
    void Start()
    {
        
        currentRailSpeed = normRailSpeed;
        currentmeterState = meterState.full; 
        accelMeter = maxAccelMeter;  
        
    }
    private void Awake()
    {

        gameInput = new Game_Inputs();
    }
    // Update is called once per frame
    void Update()
    {

      shipMoveResource();
      
    }

    public float getShipRailSpeed()
    {
        return currentRailSpeed; 
    }

    
    private void shipMoveResource() {
       accelMeter =  Mathf.Clamp(accelMeter, 0, maxAccelMeter);
        if (currentmeterState == meterState.full || currentmeterState == meterState.inUse )
        {
            if (gameInput.Ship.Boost.IsPressed())
            {
                decreaseMeter();
                if (currentRailSpeed <= maxRailSpeed) currentRailSpeed += speedIncrement;
            }

            else if (gameInput.Ship.Brake.IsPressed())
            {
                decreaseMeter();
                if (currentRailSpeed >= minRailSpeed) currentRailSpeed -= speedIncrement;
            } 
            // only becomes in use once the player lets go either boost or brake
            else if(currentmeterState == meterState.inUse){
                currentmeterState = meterState.empty; 
            }
        }
        
        else if (currentmeterState == meterState.empty) {
             increaseMeter();  
            currentRailSpeed = normRailSpeed; 
        }
        

    }



    private void increaseMeter()
    {
        accelMeter += accelIncrement;
        if (accelMeter >= maxAccelMeter) currentmeterState = meterState.full; 
    }

    private void decreaseMeter() {
        if (accelMeter > 0)
        {
            accelMeter -= accelIncrement;
            currentmeterState = meterState.inUse;
        }
        else currentmeterState = meterState.empty; 
    }

    

    
        private void OnEnable()
        {
            

            gameInput.Ship.Boost.Enable();
            gameInput.Ship.Brake.Enable();
        }

        private void OnDisable()
        {
            

            gameInput.Ship.Boost.Disable();
            gameInput.Ship.Brake.Disable();
        }

   
}
