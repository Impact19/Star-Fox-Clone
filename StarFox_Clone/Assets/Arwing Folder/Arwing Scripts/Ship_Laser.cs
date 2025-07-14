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
    [SerializeField] private GameObject laserCannon;
    [SerializeField] private AudioClip laserSfx;
    private AudioSource audioSource; 

    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    void Start()
    {
        spawnLaserPool();
        audioSource = GetComponent<AudioSource>();
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
            laserPool[x] = Instantiate(laserObject);
            laserPool[x].SetActive(false); 
        }
    }

    private void shootLaser(InputAction.CallbackContext context) {
        if (context.started)
        {
            Debug.Log("Shoot Laser");
            audioSource.clip = laserSfx;
            audioSource.Play();
            getLaser().transform.position = laserCannon.transform.position; 

        }

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
