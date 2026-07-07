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
    [SerializeField] private Transform shipTurret;
    [SerializeField] private Bomb_Properties bProps;
    [SerializeField] private Bomb_Explosion_Properties exploProps;
    void Start()
    {
        isBombFired = false;
        bombRigidBody = bomb.GetComponent<Rigidbody>();
        bProps = bomb.GetComponent<Bomb_Properties>();
        exploProps = bombExplosion.GetComponent<Bomb_Explosion_Properties>();  
     
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
         
            if (!isBombFired && !exploProps.gameObject.activeSelf && bombAmount > 0)
            {
                Debug.Log("Shot Bomb");
                bombAmount--;
                bProps.transform.position = shipTurret.position; 
                bProps.gameObject.SetActive(true); 
                isBombFired = true;
            }
            else if(isBombFired && bProps.gameObject.activeSelf)
            {
                Debug.Log("Denoated Bomb");
                exploProps.transform.position = bProps.transform.position; 
                bProps.gameObject.SetActive(false); 
                exploProps.gameObject.SetActive(true); 
               
                isBombFired = false;
            }
        
    }

    private void loadBombs() {  
        
    }

    public void increaseBomb(float bombs) { 
        if(bombAmount < bombMax) bombAmount += bombs; 
    }   

    private void OnEnable()
    {
        gameInput.Ship.Bomb.Enable();
        gameInput.Ship.Bomb.started += fireBomb;
       // gameInput.Ship.Bomb.canceled += fireBomb; 
    }

    private void OnDisable()
    {
        gameInput.Ship.Bomb.Disable();
        gameInput.Ship.Bomb.started -= fireBomb;
        // gameInput.Ship.Bomb.canceled -= fireBomb; 
    }

    
}
