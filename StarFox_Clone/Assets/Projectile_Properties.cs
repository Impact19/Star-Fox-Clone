using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Properties : MonoBehaviour
{
    [SerializeField] protected float projectileDamage;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float lifeTime;
    [SerializeField] [Range(1, -1)] protected float direction; 
    protected Rigidbody projectileRB;
    protected float ogLifeTime;
    protected Enemy_Behavior hitEnemy;
    protected Ship_Rail_Movement shipRail; 


    // Start is called before the first frame update
    protected void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
        projectileRB.useGravity = false; 
        ogLifeTime = lifeTime;
        gameObject.SetActive(false);
        shipRail = GameManager.Instance.player.GetComponent<Ship_Rail_Movement>();
        direction = Mathf.Sign(shipRail.getShipRailSpeed() ); 
    }

    // Update is called once per frame
   protected void Update()
    {
        if (gameObject.activeSelf)
        {
            projectileLifeTime();
        }
        Debug.Log("Ship Rail Speed Sign: " + Mathf.Sign(shipRail.getShipRailSpeed()));
    }

    protected void FixedUpdate()
    {
       
        projectileRB.velocity = new Vector3(0, 0, direction * projectileSpeed);
    }

    protected virtual void removeProjectile ()
    {
        gameObject.SetActive(false);
        lifeTime = ogLifeTime;
    }

    protected void projectileLifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            removeProjectile();
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy_Behavior>() != null)
        {
            hitEnemy = other.gameObject.GetComponent<Enemy_Behavior>();
            hitEnemy.OnDamage(projectileDamage);
        }
        

    }

    
}
