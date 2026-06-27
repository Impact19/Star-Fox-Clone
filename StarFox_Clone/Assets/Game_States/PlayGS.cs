using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGS : Game_State
{
    [SerializeField] private GameObject player; 
    [SerializeField] private Game_Inputs gameInput;
    [SerializeField] private Ship_Health playerHealth;
    private Game_State currentState; 
   

    private void Start()
    {

        
        currentState = GameManager.Instance.GSM.currentGameState;
        playerHealth = player.GetComponent<Ship_Health>(); 
    }
    private void Awake()
    {
        gameInput = new Game_Inputs();
    }
    public override void changeState(Game_State nextState)
    {
        gameInput.Ship.Disable();
        GameManager.Instance.GSM.currentGameState = nextState;
    }

    public override void playState()
    {
        Time.timeScale = 1f; 
        if (playerHealth.isDead)
        {
            changeState(GameManager.Instance.GSM.deathGameState);
           
        } 
        

    }
}
