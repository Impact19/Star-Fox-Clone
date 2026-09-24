using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile_Properties
{

    [SerializeField] private Transform player;
    [SerializeField] private float turnSpeed;  

    private void FixedUpdate()
    {
        moveMissile();

    }

    private void OnDrawGizmos()
    {
        
    }

    private void moveMissile() {
        float railForward = direction * projectileSpeed; 
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime); 
        Vector3 playDirection = player.position - transform.position; 

        float DotY = Vector3.Dot(gameObject.transform.up, playDirection);
        float DotX = Vector3.Dot(gameObject.transform.right, playDirection);

        float yawAmount = DotX * turnSpeed * Time.deltaTime; 
        float pitchAmount = DotY * turnSpeed * Time.deltaTime; 

        transform.Rotate(-pitchAmount, yawAmount, 0f, Space.Self); 

        Debug.DrawRay(transform.position, Vector3.forward);  
    } 


}
