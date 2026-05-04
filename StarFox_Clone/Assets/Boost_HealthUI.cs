using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boost_HealthUI : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Image boostFill; 
    private Ship_Rail_Movement shipRail; 
    public Slider slider;
    public Gradient gradient;
    [SerializeField] private Color meterinUse, meterFull; 
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

        if (slider.value < slider.maxValue) boostFill.color = meterinUse;
        else boostFill.color = meterFull; 
    }
}
