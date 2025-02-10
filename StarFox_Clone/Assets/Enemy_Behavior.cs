using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] protected float enemyHP;
    [SerializeField] private string enemyName;
    [SerializeField] private Material onDamageMaterial, standardMaterial;
    [SerializeField] private Material currentMaterial; 
    public delegate void onDamageDelegate(float damage);
    public event onDamageDelegate onDamageEvent; 
    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = gameObject.GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamage(float damage) {
        enemyHP -= damage;
        currentMaterial = onDamageMaterial;
        Debug.Log(enemyName + "Damaged"); 
        // is Dead
        if (enemyHP <= 0)
        {
            Debug.Log(enemyName + "is Destroyed");
            gameObject.SetActive(false);
        }
        else {
            currentMaterial = standardMaterial; 
        }
    }

    private void OnEnable()
    {
        onDamageEvent += OnDamage; 
    }

    private void OnDisable()
    {
        onDamageEvent -= OnDamage; 
    }
}
