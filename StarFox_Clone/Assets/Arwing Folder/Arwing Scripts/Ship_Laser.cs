using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ship_Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] laserPool;
    [SerializeField] private GameObject laserObject;
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
        spawnLaserPool();
        laserLevelIndex = 0;  

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(laserCannon.transform.position, laserCannon.transform.forward, Color.green);
    }

    private GameObject getLaser() {

        for (int x = 0; x < laserPool.Length; x++) {
            if (!laserPool[x].activeSelf)
            {
                laserPool[x].SetActive(true);
                return laserPool[x];
            }
        }
        return null; 
        
    }

    private void spawnLaserPool() { 
        laserPool = new GameObject[laserAmount];  
        for (int x = 0; x < laserAmount; x++) {
          if(laserPool[x] != null) Destroy(laserPool[x]);
            laserPool[x] = Instantiate(laserObject);
            laserPool[x].SetActive(false); 
        }
    }

    private void deleteLaserPool() {
        for (int x = 0; x < laserAmount; x++) {
            Destroy(laserPool[x]); 
        }
    }
    

    private void upgradeLaser() { 

        if(laserLevelIndex < laserLevelMax) laserLevelIndex++; 
        laserObject = laserLevels[laserLevelIndex];
        deleteLaserPool(); 
        spawnLaserPool(); 
    }


    private void shootLaser(InputAction.CallbackContext context) {
        if (context.started)
        {
            Debug.Log("Shoot Laser");
            getLaser().transform.position = laserCannon.transform.position + offset; 

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
