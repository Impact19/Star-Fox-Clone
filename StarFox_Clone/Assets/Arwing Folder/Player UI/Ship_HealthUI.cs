using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Ship_HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Ship_Health shipHealth;
    public Slider slider;
    
    private void Start()
    {
        shipHealth = player.GetComponent<Ship_Health>();
        slider = GetComponent<Slider>(); 
        slider.maxValue = shipHealth.maxHealth;
        slider.minValue = 0;  
    }

    private void Update()
    {
        slider.value = shipHealth.shipHealth; 
    }
}
