using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Properties : MonoBehaviour
{
    [SerializeField] protected float projectileDamage;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] [Range(1, -1)] protected float projectileDirection;
    [SerializeField] protected Rigidbody projectileRB;
    [SerializeField] protected float spawnTime;
    protected float ogSpawnTime;
    protected Enemy_Behavior hitEnemy;


    // Start is called before the first frame update
    protected void Start()
    {
        projectileRB = GetComponent<Rigidbody>();
        ogSpawnTime = spawnTime;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
   protected void Update()
    {
        if (gameObject.activeSelf)
        {
            projectileLifeTime();
        }
    }

    protected void FixedUpdate()
    {
        projectileRB.velocity = new Vector3(0, 0, projectileDirection * projectileSpeed);
    }

    public virtual void removeProjectile ()
    {
        gameObject.SetActive(false);
        spawnTime = ogSpawnTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitEnemy = collision.gameObject.GetComponent<Enemy_Behavior>();
        hitEnemy.OnDamage(projectileDamage);
    }

    protected void projectileLifeTime()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
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
