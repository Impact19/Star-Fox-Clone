using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Ship_Movement : MonoBehaviour 
{
    [SerializeField] private Rigidbody shipRB;
    [SerializeField] private Game_Input gameInput; 
   
    [Header("Standard Ship Movement")]
    [SerializeField] private Vector2 shipSpeed, standardRotation;
    [SerializeField] private float  rotationSpeed;
     private Vector3 startRotation;
    
    [Header("Tilt Movement Variables")]
    [SerializeField] private bool isGliding;
    [SerializeField] private float glideSpeedBoost, glideRotation;

    private void Awake()
    {
        gameInput = new Game_Input();
        shipRB = GetComponent<Rigidbody>();

    }
    void Start()
    {
        startRotation = gameObject.transform.rotation.eulerAngles; 
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void shipMovementInput(InputAction.CallbackContext context) {
        Debug.Log("Ship Moving");
        Vector2 shipVector = context.ReadValue<Vector2>();
     
        if (isGliding)
        {
            shipRB.velocity = shipVector *  shipSpeed * glideSpeedBoost;
            shipRotation(shipVector, new Vector2(standardRotation.x, standardRotation.y * glideRotation));
        }
        else {
            shipRB.velocity = shipVector * shipSpeed;
            shipRotation(shipVector, standardRotation);
        }
       



    }

    private void shipMovement(float shipSpeed, float Rotation) {  
    
    }

    private void shipTiltInput(InputAction.CallbackContext context) {
        Debug.Log("Is Ship Tilting : " + isGliding);
        isGliding = context.ReadValue<float>() >= 0.1;
    }

    private void shipRotation(Vector2 shipVector, Vector2 rotation) {
        Vector3 shipRotation = new Vector3(-shipVector.y * rotation.x, gameObject.transform.rotation.y, -shipVector.x * rotation.y); 
         gameObject.transform.rotation = Quaternion.Slerp(Quaternion.Euler(startRotation), Quaternion.Euler(shipRotation), rotationSpeed); 
    } 




    private void OnEnable()
    {
        gameInput.Ship.Movement.performed += shipMovementInput;
        gameInput.Ship.Movement.canceled += shipMovementInput;
        gameInput.Ship.Glide.performed += shipTiltInput;
        gameInput.Ship.Glide.canceled += shipTiltInput; 
        gameInput.Ship.Movement.Enable();
        gameInput.Ship.Glide.Enable(); 
    }

    private void OnDisable()
    {
        gameInput.Ship.Movement.performed -= shipMovementInput;
        gameInput.Ship.Movement.canceled -= shipMovementInput;
        gameInput.Ship.Glide.performed -= shipTiltInput;
        gameInput.Ship.Glide.canceled -= shipTiltInput;
        gameInput.Ship.Movement.Disable();
        gameInput.Ship.Glide.Disable(); 
    }

    private void moveInputsEnable(InputAction action, Delegate function) {
       
    }

}
