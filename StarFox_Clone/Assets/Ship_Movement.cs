using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship_Movement : MonoBehaviour 
{
    [SerializeField] private Rigidbody shipRB;
    [SerializeField] private Game_Input gameInput; 
    [Header("Standard Ship Movement")]
    [SerializeField] private float shipSpeedX, shipSpeedY;
    [SerializeField] private Vector2 shipSpeed, standardRotation;
    [SerializeField] private float  rotationSpeed;
     private Vector3 defaultRotation;
    [Header("Tilt Movement Variables")]
    [SerializeField] private float tiltSpeed, tiltRotation;
     private enum shipTilt {tiltLeft,noTilt,tiltRight };
    [SerializeField] private shipTilt currentTilt; 

    private void Awake()
    {
        gameInput = new Game_Input();
        shipRB = GetComponent<Rigidbody>();

    }
    void Start()
    {
        defaultRotation = gameObject.transform.rotation.eulerAngles; 
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void shipMovementInput(InputAction.CallbackContext context) {
        Debug.Log("Ship Moving");
        Vector2 shipVector = context.ReadValue<Vector2>();
        if (currentTilt == shipTilt.noTilt)
        {
            shipRB.velocity = shipVector * shipSpeed;
            shipRotation(shipVector, standardRotation);
        }



    }

    private void shipMovement(float shipSpeed, float Rotation) {  
    
    }

    private void shipTiltInput(InputAction.CallbackContext context) {
        Debug.Log("Ship Tilt");
        float input = context.ReadValue<float>();
        if (input == -1) currentTilt = shipTilt.tiltLeft;
        else if (input == 1) currentTilt = shipTilt.tiltRight;
        else currentTilt = shipTilt.noTilt; 
    }

    private void shipRotation(Vector2 shipVector, Vector2 rotation) {
        Vector3 shipRotation = new Vector3(-shipVector.y * rotation.x, gameObject.transform.rotation.y, -shipVector.x * rotation.y); 
         gameObject.transform.rotation = Quaternion.Slerp(Quaternion.Euler(defaultRotation), Quaternion.Euler(shipRotation), rotationSpeed); 
    } 




    private void OnEnable()
    {
        gameInput.Ship.Movement.performed += shipMovementInput;
        gameInput.Ship.Movement.canceled += shipMovementInput;
        gameInput.Ship.Tilt.performed += shipTiltInput;
        gameInput.Ship.Tilt.canceled += shipTiltInput; 
        gameInput.Ship.Movement.Enable();
        gameInput.Ship.Tilt.Enable(); 
    }

    private void OnDisable()
    {
        gameInput.Ship.Movement.performed -= shipMovementInput;
        gameInput.Ship.Movement.canceled -= shipMovementInput;
        gameInput.Ship.Tilt.performed -= shipTiltInput;
        gameInput.Ship.Tilt.canceled -= shipTiltInput;
        gameInput.Ship.Movement.Disable();
        gameInput.Ship.Tilt.Disable(); 
    }



}
