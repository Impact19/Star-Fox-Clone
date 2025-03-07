using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Ship_Movement : MonoBehaviour 
{
    [SerializeField] private Rigidbody shipRB;
    [SerializeField] private Game_Input gameInput;
    public GameObject shipGameObject; 
   
    [Header("Standard Ship Movement")]
    [SerializeField] private Vector2 standardRotation;
    [SerializeField] private Vector2 shipSpeed;
    [SerializeField] private float  rotationSpeed;
     private Vector3 startRotation; 

    [Header("Ship Rail Variables")]
    [SerializeField] private float currentRailSpeed;
    [SerializeField] private float normRailSpeed;
    [SerializeField] private float maxRailSpeed;
    [SerializeField] private float minRailSpeed; 
    [SerializeField] private float boostAccel;
    [SerializeField] private float brakeAccel;
    private enum speedState {normal,boost,brake };
    [SerializeField] private speedState currentSpeedState; 


    [Header("Tilt Movement Variables")]
    [SerializeField] private bool isGliding;
    [SerializeField] private float glideSpeedBoost, glideRotation;

    private void Awake()
    {
        gameInput = new Game_Input();
        shipRB = GetComponent<Rigidbody>();
        shipGameObject = gameObject;
    }
    void Start()
    {
        startRotation = gameObject.transform.rotation.eulerAngles;
        isGliding = false;
        currentRailSpeed = normRailSpeed;
        currentSpeedState = speedState.normal; 
    }

    // Update is called once per frame
    void Update()
    {
        shipRailMovement(); 
    }

    private void shipMovementInput(InputAction.CallbackContext context) {
        Debug.Log("Ship Moving");  
        Vector2 shipVector = context.ReadValue<Vector2>();
     
        if (isGliding)
        {
            shipRB.velocity =  new Vector3(shipVector.x *  shipSpeed.x * glideSpeedBoost, shipVector.y * shipSpeed.y * glideSpeedBoost, currentRailSpeed);
            shipRotation(shipVector, new Vector2(standardRotation.x, standardRotation.y * glideRotation));
        }
        else {
            shipRB.velocity = new Vector3(shipVector.x * shipSpeed.x, shipVector.y * shipSpeed.y, currentRailSpeed);
            shipRotation(shipVector, standardRotation);
        }
      
    }

    public float getShipRailSpeed(){
        return currentRailSpeed; 
    }

    
    private void shipTiltInput(InputAction.CallbackContext context) {
        Debug.Log("Is Ship Tilting : " + isGliding);
        isGliding = context.ReadValue<float>() >= 0.1;
    }

    private void shipRotation(Vector2 shipVector, Vector2 rotation) {
        Vector3 shipRotation = new Vector3(-shipVector.y * rotation.x, gameObject.transform.rotation.y, -shipVector.x * rotation.y); 
         gameObject.transform.rotation = Quaternion.Slerp(Quaternion.Euler(startRotation), Quaternion.Euler(shipRotation), rotationSpeed); 
    }

    private void shipBoost(InputAction.CallbackContext context) { 
        if(currentRailSpeed <= maxRailSpeed) currentRailSpeed += boostAccel; 
    }

    private void shipBrake(InputAction.CallbackContext context) {
        if (currentRailSpeed >= minRailSpeed) currentRailSpeed -= brakeAccel;
    }

    private void shipRailMovement() {
        if (currentSpeedState == speedState.normal)
        {
            currentRailSpeed = normRailSpeed;
        }
        else if (currentSpeedState == speedState.boost && currentRailSpeed <= maxRailSpeed)
        {
            currentRailSpeed += boostAccel;
        }
        else if (currentSpeedState == speedState.brake && currentRailSpeed >= minRailSpeed)  
        {
            currentRailSpeed -= brakeAccel;
        }
    }


    private void OnEnable()
    {
        gameInput.Ship.Movement.performed += shipMovementInput;
        gameInput.Ship.Movement.canceled += shipMovementInput;
        gameInput.Ship.Glide.performed += shipTiltInput;
        gameInput.Ship.Glide.canceled += shipTiltInput;

        gameInput.Ship.Boost.performed += ctx => currentSpeedState = speedState.boost;
        gameInput.Ship.Boost.canceled += ctx => currentSpeedState = speedState.normal;
        gameInput.Ship.Brake.performed += ctx => currentSpeedState = speedState.brake;
        gameInput.Ship.Brake.canceled += ctx => currentSpeedState = speedState.normal; 
        
        gameInput.Ship.Movement.Enable();
        gameInput.Ship.Glide.Enable();
        gameInput.Ship.Boost.Enable();
        gameInput.Ship.Brake.Enable();
    }

    private void OnDisable()
    {
        gameInput.Ship.Movement.performed -= shipMovementInput;
        gameInput.Ship.Movement.canceled -= shipMovementInput;
        gameInput.Ship.Glide.performed -= shipTiltInput;
        gameInput.Ship.Glide.canceled -= shipTiltInput;
       
        gameInput.Ship.Boost.performed -= ctx => currentSpeedState = speedState.boost;
        gameInput.Ship.Boost.canceled -= ctx => currentSpeedState = speedState.normal;
        gameInput.Ship.Brake.performed -= ctx => currentSpeedState = speedState.brake;
        gameInput.Ship.Brake.canceled -= ctx => currentSpeedState = speedState.normal;
       
        gameInput.Ship.Movement.Disable();
        gameInput.Ship.Glide.Disable();
        gameInput.Ship.Boost.Disable();
        gameInput.Ship.Brake.Disable();
    }

    private void moveInputsEnable(InputAction action, Delegate function) {
       
    }

}
