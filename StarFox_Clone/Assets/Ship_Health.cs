using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Health : MonoBehaviour
{
    [SerializeField] private float shipHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private string terrainTag;
    [SerializeField] private string enemyTag; 
    [SerializeField] private float terrainDamage;
    [SerializeField] private string healthTag;
    [SerializeField] private float healthGain;
    [SerializeField] private AudioClip shipHitSound;
    public delegate void changeHealth(float health);
    public event changeHealth gainedHealth;
    public event changeHealth lostHealth; 

    private AudioSource audioSource; 
    private void Start()
    {
        shipHealth = maxHealth;
        audioSource = GetComponent<AudioSource>(); 
    }

    private void onDamage(float damage) { 
        shipHealth -= damage;
        Debug.Log("Ship took: " + damage + " damage");
        audioSource.clip = shipHitSound;
        audioSource.Play(); 
        if (shipHealth <= 0) OnDeath(); 
    }

    private void onHealth(float health) {
        Debug.Log("Ship gained: " + health + " health");  
        if(shipHealth <= maxHealth) shipHealth += health;
    }

    private void OnDeath() {
        Debug.Log("Player has died"); 
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
