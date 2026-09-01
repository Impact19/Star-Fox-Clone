using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ship_Laser : MonoBehaviour
{
    public Laser_Pool laserPool; 
    [SerializeField] private GameObject[] laserLevels;
    [SerializeField] private int laserLevelIndex, laserLevelMax;
    [SerializeField] private int laserAmount;
    [SerializeField] private Game_Inputs gameInput;
    [SerializeField] private GameObject laserCannon;
    [SerializeField] private Vector3 offset;
    [SerializeField] private string laserUPTag; 

    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    void Start()
    {
        laserPool = GetComponent<Laser_Pool>();
        laserPool.laserObject = laserLevels[laserLevelIndex];
        laserPool.laserAmount = laserAmount;
        laserPool.spawnLaserPool();
        laserLevelIndex = 0;  

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(laserCannon.transform.position, laserCannon.transform.forward, Color.green);
    }

    

    private void upgradeLaser() { 

        if(laserLevelIndex < laserLevelMax) laserLevelIndex++; 
        laserPool.laserObject = laserLevels[laserLevelIndex];
        laserPool.deleteLaserPool(); 
        laserPool.spawnLaserPool(); 
    }


    private void shootLaser(InputAction.CallbackContext context) {
        if (context.started)
        {
            Debug.Log("Shoot Laser");
            laserPool.getLaser().transform.position = laserCannon.transform.position + offset; 

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == laserUPTag) upgradeLaser(); 
    }

    private void OnEnable()
    {
        gameInput.Ship.Shoot.Enable();
        gameInput.Ship.Shoot.started += shootLaser;
        gameInput.Ship.Shoot.canceled += shootLaser;
        

    }

    private void OnDisable()
    {
        gameInput.Ship.Shoot.Disable(); 
        gameInput.Ship.Shoot.started -= shootLaser;
        gameInput.Ship.Shoot.canceled -= shootLaser;
    }
}
