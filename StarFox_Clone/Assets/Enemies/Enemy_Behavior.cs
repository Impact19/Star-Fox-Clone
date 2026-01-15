using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] protected float enemyHP;
    [SerializeField] private string enemyName;
    [SerializeField] private Material onDamageMaterial, standardMaterial;
    [SerializeField] private Material currentMaterial;
   
    [SerializeField] private AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = gameObject.GetComponent<Renderer>().material;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDamage(float damage)
    {
        enemyHP -= damage;
        currentMaterial = onDamageMaterial;
        Debug.Log(enemyName + " Damaged");
        // is Dead
        if (enemyHP <= 0)
        {
            onDeath();
        }
        else
        {
            currentMaterial = standardMaterial;
        }
    }

    private void onDeath()
    {
        Debug.Log(enemyName + " is Destroyed");
        GameManager.Instance.audioSource.clip = explosionClip;
        GameManager.Instance.audioSource.Play(); 
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

}
