using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro; 

public class Ship_Bombs : MonoBehaviour
{
    private Game_Inputs gameInput;
    [SerializeField] private Projectile_Properties bomb, bombExplo;
    [SerializeField] private float bombAmount, bombMax;
    [SerializeField] private TMP_Text bombAmountUI; 
    [SerializeField] private string bombItemTag; 
    [SerializeField] private Transform shipTurret;
     
    
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        bombAmountUI.text = bombAmount.ToString();

    }

    private void FixedUpdate()
    { 
        if(!bomb.gameObject.activeSelf) bomb.transform.position = shipTurret.position;
    }
    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    private void fireBomb(InputAction.CallbackContext context) {
        bool isBombActive = bomb.gameObject.activeSelf;
        bool isExploActive = bombExplo.gameObject.activeSelf;  

            if (!isBombActive && !isExploActive && bombAmount > 0)
            {
                Debug.Log("Shot Bomb");
                bombAmount--;
                bomb.gameObject.SetActive(true); 
              
            }
            else if(isBombActive && !isExploActive)
            {
                exploBomb(); 
            }
        
    }

    private void exploBomb() {
        Debug.Log("Denoated Bomb");
        bombExplo.transform.position = bomb.transform.position;
        bombExplo.gameObject.SetActive(true);
        bomb.removeProjectile();
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
