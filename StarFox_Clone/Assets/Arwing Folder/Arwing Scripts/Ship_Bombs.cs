using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro; 

public class Ship_Bombs : MonoBehaviour
{
    [SerializeField] private GameObject bomb, bombExplosion;
    private Rigidbody bombRigidBody; 
    private Game_Inputs gameInput; 
    [SerializeField] private float bombAmount, bombMax;
    [SerializeField] private TMP_Text bombAmountUI; 
    [SerializeField] private float bombDamage;
    [SerializeField] private float bombSpeed; 
    [SerializeField] private bool isBombFired;
    [SerializeField] private string bombItemTag; 
    [SerializeField] Vector3 shipTurret;  
    void Start()
    {
        isBombFired = false;
        bombRigidBody = bomb.GetComponent<Rigidbody>();  

    }

    // Update is called once per frame
    void Update()
    {
        bombAmountUI.text = bombAmount.ToString(); 
    }
    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    private void fireBomb(InputAction.CallbackContext context) {
        if (!isBombFired && bombAmount > 0)
        {
            Debug.Log("Shot Bomb");
            bomb.SetActive(true); 
            bombRigidBody.position = shipTurret;
            bombRigidBody.velocity = new Vector3(0, 0, bombSpeed); 
            bombAmount--;  
            
            isBombFired = true;
        }
        else {
            Debug.Log("Fired Bomb"); 
            bombExplosion.SetActive(true);
            isBombFired = false; 
        }
    }

    public void increaseBomb(float bombs) {
        bombAmount += bombs; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == bombItemTag) {
            increaseBomb(other.gameObject.GetComponent<ICollectible>().getCollectibleAmount()); 
        }
    }

    private void OnEnable()
    {
        gameInput.Ship.Bomb.Enable();
        gameInput.Ship.Bomb.performed += fireBomb; 
    }

    private void OnDisable()
    {
        gameInput.Ship.Bomb.Disable();
        gameInput.Ship.Bomb.performed -= fireBomb; 
    }

    
}
