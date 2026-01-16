using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private float healthAmount;
    [SerializeField] private AudioClip healClip;
    private AudioSource audioS;
    [SerializeField] private float floatSpeed;
    [SerializeField] private float floatHeight;
    private Vector3 startPosition; 
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip = healClip;
        startPosition = transform.position; 
    }

    private void Update()
    {
        floatItem(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag) {
            GameManager.Instance.audioSource.clip = healClip;
            GameManager.Instance.audioSource.Play();  
            gameObject.SetActive(false);         
        }
    }

    public float getHealing() {
        return healthAmount;
    }

    private void floatItem() {
        float changeY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, changeY, transform.position.z); 
    }



}
