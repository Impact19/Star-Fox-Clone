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
    [SerializeField] private Vector2 shipSpeed;
    [SerializeField] private Vector3 standardRotation; 
    [SerializeField] private float shipRotationX, shipRotationZ, rotationSpeed;
     private Vector3 defaultRotation;
    [Header("Tilt Movement Variables")]
    [SerializeField] private float tiltSpeed, tiltRotation;
    [SerializeField] private bool isTilting; 

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
        shipRB.velocity = shipVector * shipSpeed;
        shipRotation(shipVector, shipRotationX, shipRotationZ); 

    }

    private void shipMovement(float shipSpeed, float Rotation) {  
    
    }

    private void shipTilt(InputAction.CallbackContext context) {
        Debug.Log("Ship Tilt");  

    }

    private void shipRotation(Vector2 shipVector, float rotationX, float rotationZ) {
        Vector3 shipRotation = new Vector3(-shipVector.y * rotationX, gameObject.transform.rotation.y, -shipVector.x * rotationZ); 
         gameObject.transform.rotation = Quaternion.Slerp(Quaternion.Euler(defaultRotation), Quaternion.Euler(shipRotation), rotationSpeed); 
    } 




    private void OnEnable()
    {
        gameInput.Ship.Movement.performed += shipMovementInput;
        gameInput.Ship.Movement.canceled += shipMovementInput; 
        gameInput.Ship.Movement.Enable();
    }

    private void OnDisable()
    {
        gameInput.Ship.Movement.performed -= shipMovementInput;
        gameInput.Ship.Movement.canceled -= shipMovementInput;
        gameInput.Ship.Movement.Disable(); 
    }



}
