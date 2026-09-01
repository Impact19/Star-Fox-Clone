using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] protected float enemyHP;
    [SerializeField] private string enemyName;
    

    [SerializeField] private AudioClip explosionClip;
    [SerializeField] private GameObject collectible;  


    // Start is called before the first frame update
    void Start()
    {
        //  currentMaterial = gameObject.GetComponent<Renderer>().material;  
        
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
        GameManager.Instance.audioSource.clip = explosionClip;
        GameManager.Instance.audioSource.Play();
        collectible.transform.position = gameObject.transform.position;
        collectible.SetActive(true); 
        gameObject.SetActive(false); 
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

}
