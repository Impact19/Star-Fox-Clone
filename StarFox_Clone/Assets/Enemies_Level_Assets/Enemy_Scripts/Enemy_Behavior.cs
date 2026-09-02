using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] protected float enemyHP;
    [SerializeField] private string enemyName;
    

    [SerializeField] private AudioClip deathClip;
    [SerializeField] private GameObject collectible;
    public bool isRandCollectible; 

    // Start is called before the first frame update
    void Start()
    {
        //  currentMaterial = gameObject.GetComponent<Renderer>().material;  
        // is c
        if(collectible == null) {
            collectible = Collectible_Randomizer.randomCollectible().gameObject;   
        }
        collectible = Instantiate(collectible);
        collectible.SetActive(false);
    }

        // Update is called once per frame
        void Update()
    {

    }

    public void OnDamage(float damage)
    {
        enemyHP -= damage;
        Debug.Log(enemyName + " Damaged");
        // is Dead
        if (enemyHP <= 0)
        {
            onDeath();
        }
        
    }

    private void onDeath()
    {
        Debug.Log(enemyName + " is Destroyed");
        GameManager.Instance.audioSource.clip = deathClip;
        GameManager.Instance.audioSource.Play();
        collectible.transform.position = gameObject.transform.position; 
        collectible.SetActive(true);
        Debug.Log(enemyName + " Spawned " + collectible.name); 
        gameObject.SetActive(false); 
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

}
