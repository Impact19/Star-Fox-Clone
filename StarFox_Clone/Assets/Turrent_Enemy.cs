using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent_Enemy : Enemy_Behavior
{
    [SerializeField] private enum turrentActions {idle,attacking,destroyed};
    [SerializeField] private bool isInRange;
    [SerializeField] private GameObject turretLasers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turretHead,turretOpening;
    [SerializeField] private float rotationStrength;
    [SerializeField] private float turretRange;
    [SerializeField] private float turretFireRate, currentFireRate; 
    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = turretFireRate; 
    }

    // Update is called once per frame
    void Update()
    {
        rotateHead();
       shootLaser(); 
    }

    private void rotateHead() {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - turretHead.transform.position);
        float str = Mathf.Min(rotationStrength * Time.deltaTime, 1);
        turretHead.transform.rotation = Quaternion.Lerp(turretHead.transform.rotation, targetRotation, str); 
    }

    private void shootLaser() {
        isInRange = (Vector3.Distance(player.transform.position, gameObject.transform.position) >= turretRange); 
       
        if (isInRange && turretFireRate > 0) {
            Debug.Log("Fire Laser");
            turretLasers.transform.position = turretOpening.transform.position; 
            turretLasers.SetActive(true);
            turretFireRate -= Time.deltaTime; 
        };
        
    }

    private bool shipInRange() {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= turretRange) return true;
        return false; 
    }
}
