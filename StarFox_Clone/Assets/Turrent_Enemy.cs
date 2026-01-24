using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent_Enemy : Enemy_Behavior
{
    [SerializeField] private enum turrentActions {idle,attacking,destroyed};
    [SerializeField] private bool isInRange;
    [SerializeField] private GameObject[] turretLasers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turretHead;
    [SerializeField] private float rotationStrength; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateHead(); 
    }

    private void rotateHead() {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - turretHead.transform.position);
        float str = Mathf.Min(rotationStrength * Time.deltaTime, 1);
        turretHead.transform.rotation = Quaternion.Lerp(turretHead.transform.rotation, targetRotation, str); 
    }

    private void shootLaser() {  
            
    }   
}
