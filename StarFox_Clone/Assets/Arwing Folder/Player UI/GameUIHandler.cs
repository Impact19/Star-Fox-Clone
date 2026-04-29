using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; 


public class GameUIHandler : MonoBehaviour
{
    public GameObject player; 
    public Ship_Health shipHealth;
    public UIDocument document;
    private Label healthLabel; 

    // Start is called before the first frame update
    void Start()
    {
        shipHealth = player.GetComponent<Ship_Health>(); 
        healthLabel = document.rootVisualElement.Q<Label>("HealthLabel"); 
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUIChanged(); 
    }

    private void healthUIChanged() { 
        // $ is used for string interpolation allowing you yo emded expressions bascially making a value that orginally wasn't a string into one. 
        healthLabel.text = $"{shipHealth.shipHealth}/{shipHealth.maxHealth}";
        float healthRatio = (float)shipHealth.shipHealth / shipHealth.maxHealth;
        float healthPercent = Mathf.Lerp(8, 88, healthRatio);
        healthLabel.style.width = Length.Percent(healthPercent); 
    }
}
