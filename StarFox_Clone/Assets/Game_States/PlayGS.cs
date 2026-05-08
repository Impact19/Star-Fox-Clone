using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGS : Game_State
{
    [SerializeField] private GameObject player; 
    [SerializeField] private Game_Input gameInput;
    [SerializeField] private Ship_Health playerHealth;
    private Game_State currentState; 
    public bool isDead = false;

    private void Start()
    {

        isDead = false; 
        currentState = GameManager.Instance.GSM.currentGameState;
        playerHealth = player.GetComponent<Ship_Health>(); 
    }
    private void Awake()
    {
        gameInput = new Game_Input();
    }
    public override void changeState(Game_State nextState)
    {
        GameManager.Instance.GSM.currentGameState = nextState; 
    }

    public override void playState()
    {
       
        if (playerHealth.isDead)
        {
            changeState(GameManager.Instance.GSM.deathGameState);
        } 
        

    }
}
