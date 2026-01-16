using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent_Enemy : Enemy_Behavior
{
    [SerializeField] private enum turrentActions {idle,attacking,destroyed};
    [SerializeField] private bool isInRange;
    [SerializeField] private GameObject[] turretLasers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turretTip, turretHead; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootLaser(); 
    }

    private void shootLaser() {
        Debug.DrawRay(turretTip.transform.position, player.transform.position);
        turretHead.transform.LookAt(player.transform); 
    }
}
