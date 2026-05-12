using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGS : Game_State
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject player;
    private Game_Input gameInput;
    public override void changeState(Game_State nextState)
    {
        gameInput.Ship.Enable();
        GameManager.Instance.GSM.currentGameState = nextState; 
    }

    public override void playState()
    {
       // Time.timeScale = 0f; 
        gameInput.UI.Enable();  
        deathMenu.SetActive(true); 
    }
    private void Awake()
    {
        gameInput = new Game_Input();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Arwing"); 
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
