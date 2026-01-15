using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private float healthAmount;
    [SerializeField] private AudioClip healClip;
    private AudioSource audioS; 
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip = healClip; 
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


}
