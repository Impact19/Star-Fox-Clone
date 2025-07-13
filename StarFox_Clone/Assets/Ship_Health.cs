using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Health : MonoBehaviour
{
    [SerializeField] private float shipHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private string terrainTag;
    [SerializeField] private float terrainDamage;
    [SerializeField] private string healthTag;
    [SerializeField] private float healthGain; 
    private void Start()
    {
        shipHealth = maxHealth; 
    }

    private void onDamage(float damage) { 
        shipHealth -= damage;
        Debug.Log("Ship took: " + damage + " damage"); 
        if (shipHealth <= 0) OnDeath(); 
    }

    private void onHealth(float health) {
        Debug.Log("Ship gained: " + health + " health"); 
        shipHealth += health;
    }

    private void OnDeath() {
        Debug.Log("Player has died"); 
    }
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == terrainTag) {
            onDamage(terrainDamage); 
        }

        


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == terrainTag)
        {
            onDamage(terrainDamage);
        }

        if (other.gameObject.tag == healthTag) onHealth(healthGain);
    }
}
