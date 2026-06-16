using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Ship_Health : MonoBehaviour
{
    public bool isDead;
    public float shipHealth;
    public float maxHealth; 
    
    [SerializeField] private string terrainTag;
    [SerializeField] private string enemyTag; 
    [SerializeField] private float terrainDamage;
    [SerializeField] private string healthTag;
    
    [SerializeField] private float healthGain;
   
    [SerializeField] private AudioClip shipHitSound;
    [SerializeField] private GameObject onDeathMenu;
    private Game_Input gameInput;
   [SerializeField] private PlayerInput player;
   [SerializeField] private InputActionMap uiActions;
    [SerializeField] private InputActionAsset inputAction; 

    public delegate void changeHealth(float health);
    public event changeHealth gainedHealth;
    public event changeHealth lostHealth; 
    


    private AudioSource audioSource;

    private void Awake()
    {
        gameInput = new Game_Input();
        player = GetComponent<PlayerInput>();
        uiActions = gameInput.UI; 
    }
    private void Start()
    {
        shipHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        onDeathMenu.SetActive(false);  

   }

    private void Update()
    {
       // isDead = shipHealth <= 0;

        if (isDead) onDeath(); 
    }

    private void onDamage(float damage) { 
        shipHealth -= damage;
        Debug.Log("Ship took: " + damage + " damage");
        audioSource.clip = shipHitSound;
        audioSource.Play(); 
      
    }

    private void onHealth(float health) {
        Debug.Log("Ship gained: " + health + " health");  
        if(shipHealth <= maxHealth) shipHealth += health;
    }

    private void onDeath() {
        onDeathMenu.SetActive(true);
        
        player.actions.FindActionMap("UI").Enable();
        player.SwitchCurrentActionMap("UI");
        Debug.Log("Player is Dead: " + player.currentActionMap);
    }

    private void switchActionMap(InputAction.CallbackContext context) {
        player.actions.FindActionMap("Ship").Disable();
        player.actions.FindActionMap("UI").Enable(); 

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == terrainTag || other.gameObject.tag == enemyTag)
        {
            lostHealth(terrainDamage);
        }

        if (other.gameObject.tag == healthTag) {
          gainedHealth(other.gameObject.GetComponent<Health_Item>().getHealing() ); 
        }
      
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == terrainTag)  {
                onDamage(terrainDamage);
            }
    }

    private void OnEnable()
    { 
        gainedHealth += onHealth;
        lostHealth += onDamage;  
        
    }
    private void OnDisable()
    {
        gainedHealth -= onHealth;
        lostHealth -= onDamage; 
    }
}
