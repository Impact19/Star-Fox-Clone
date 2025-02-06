using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ship_Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] laserPool;
    [SerializeField] private GameObject laserObject;
    [SerializeField] private int laserAmount;
    [SerializeField] private Game_Inputs gameInput;
    [SerializeField] private float laserSpeed; 
    private int latestLaser, readyLaser;

    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    void Start()
    {
        spawnLaserPool();
  
    }

    // Update is called once per frame
    void Update()
    {
        
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
            laserPool[x] = Instantiate(laserObject, gameObject.transform);
            laserPool[x].SetActive(false); 
        }
    }

    private void shootLaser(InputAction.CallbackContext context) {
        Debug.Log("Shoot Laser");
        getLaser().GetComponent<Rigidbody>().velocity = gameObject.transform.forward * laserSpeed; 

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
