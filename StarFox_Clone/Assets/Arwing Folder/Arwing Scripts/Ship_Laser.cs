using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ship_Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] laserPool;
    [SerializeField] private GameObject laserObject;
    [SerializeField] private int laserAmount;
    [SerializeField] private Game_Input gameInput;
    private int latestLaser, readyLaser;

    private void Awake()
    {
        gameInput = new Game_Input();
    }
    void Start()
    {
        spawnLaserPool();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getLaser() {

        for (int x = 0; x < laserPool.Length; x++) {
            laserPool[x].SetActive(true);
        }
        
    }

    private void spawnLaserPool() {
        laserPool = new GameObject[laserAmount]; 
        for (int x = 0; x < laserAmount; x++) {
            laserPool[x] = Instantiate(laserObject, gameObject.transform);
            laserPool[x].SetActive(false); 
        }
    }

    private void shootLaser(InputAction.CallbackContext context) {
        Debug.Log("Shoot Laser");
        getLaser(); 

    }

    private void OnEnable()
    {
        gameInput.Ship.Shoot.Enable();
        gameInput.Ship.Shoot.performed += shootLaser;
        gameInput.Ship.Shoot.canceled += shootLaser;


    }

    private void OnDisable()
    {
        gameInput.Ship.Shoot.Disable(); 
        gameInput.Ship.Shoot.performed -= shootLaser;
        gameInput.Ship.Shoot.performed -= shootLaser;
    }
}
