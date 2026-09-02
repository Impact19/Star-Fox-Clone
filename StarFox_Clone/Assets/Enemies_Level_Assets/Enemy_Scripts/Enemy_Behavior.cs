using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] protected float enemyHP;
    [SerializeField] private string enemyName;
    

    [SerializeField] private AudioClip deathClip;
    [SerializeField] private GameObject collectible;
    public  ICollectible[] collectibles;
    public ICollectible bomb, health, laser;
    private float nullCol = 20; 

    // Start is called before the first frame update
    void Start()
    {
        //  currentMaterial = gameObject.GetComponent<Renderer>().material;  
        // is c
        if(collectible == null) {
            collectible = randomCollectible().gameObject;   
        }
        collectible = Instantiate(collectible);
        collectible.SetActive(false);
    }

    public void Awake()
    {
        collectibles = new ICollectible[3];
        collectibles[0] = health;
        collectibles[1] = bomb;
        collectibles[2] = laser;
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

   

    private ICollectible randomCollectible()
    {
        float rand = Random.Range(0f, totalWeight());
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (rand < collectibles[i].spawnChance)
            {

                return collectibles[i];
            }
            rand -= collectibles[i].spawnChance;
        }
        return null;
    }

    private float totalWeight()
    {
        float total = 0;
        for (int i = 0; i < collectibles.Length; i++)
        {
            total += collectibles[i].spawnChance;

        }
        return total;
    }


}
