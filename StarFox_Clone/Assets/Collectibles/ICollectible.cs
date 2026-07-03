using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollectible : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] protected float floatSpeed;
    [SerializeField] protected float floatHeight;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected float collectibleIncrease;
    [SerializeField] protected string playerTag;
    [SerializeField] protected AudioClip collectibleClip;
    private AudioSource audioS; 
    protected void Start()
    {
        startPosition = transform.position;
        audioS = GetComponent<AudioSource>();
        audioS.clip = collectibleClip;  
        
    }

    protected void Update()
    {
        floatItem();
    }
    protected void floatItem()
    {
        float changeY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, changeY, transform.position.z);
    }

    protected void rotateItem() {
        float changex = transform.rotation.x + Mathf.Cos(Time.time * rotateSpeed); 
        transform.rotation = new Quaternion(changex, transform.rotation.y, transform.rotation.z, transform.rotation.w); 
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            GameManager.Instance.audioSource.clip = collectibleClip;
            GameManager.Instance.audioSource.Play();
            gameObject.SetActive(false);
        }
    }

    public float getCollectibleAmount() {
        return collectibleIncrease; 
    }

    private void OnDrawGizmos()
    {
       
    }
}
