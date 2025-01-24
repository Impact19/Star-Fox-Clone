using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ship_Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private int laserAmount;
    [SerializeField] private Game_Input gameInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void laserPool() { 

    }

    private void shootLaser(InputAction.CallbackContext context) {
        Debug.Log("Shoot Laser"); 
    }

    private void OnEnable()
    {
        gameInput.Ship.Shoot.performed += shootLaser;
        gameInput.Ship.Shoot.canceled += shootLaser;
    }

    private void OnDisable()
    {
        gameInput.Ship.Shoot.performed -= shootLaser;
        gameInput.Ship.Shoot.performed -= shootLaser;
    }
}
