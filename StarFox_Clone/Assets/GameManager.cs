using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource audioSource { get; private set; }
    public Game_State_Manager GSM; 
    

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this; 
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GSM = GetComponent<Game_State_Manager>();
    }


}
