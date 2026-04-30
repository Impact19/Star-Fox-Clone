using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boost_HealthUI : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Ship_Rail_Movement shipRail; 
    public Slider slider;
    public Gradient gradient;

    private void Start()
    {
        shipRail = player.GetComponent<Ship_Rail_Movement>();
        slider = GetComponent<Slider>();
        slider.maxValue = shipRail.maxAccelMeter;
        slider.minValue = 0; 
    }

    private void Update()
    {
        slider.value = shipRail.accelMeter; 
    }
}
