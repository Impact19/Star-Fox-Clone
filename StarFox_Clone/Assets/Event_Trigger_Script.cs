using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Trigger_Script : MonoBehaviour
{
     public List<GameObject> enableObjects = new List<GameObject>();
    [SerializeField] private GameObject player;

    private void Start()
    {
        onDisableObjects(); 
    }

    private void OnEnableObjects() {
        foreach (GameObject items in enableObjects) {
            items.SetActive(true); 
        }
    }

    private void onDisableObjects() {
        foreach (GameObject items in enableObjects)
        {
            items.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player triggered event" + gameObject.name); 
            OnEnableObjects();
        }
    }


}
