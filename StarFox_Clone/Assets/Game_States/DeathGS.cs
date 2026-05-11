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
        throw new System.NotImplementedException();
    }

    public override void playState()
    {
        deathMenu.SetActive(true); 
    }

    // Start is called before the first frame update
    void Start()
    {
        gameInput = player.GetComponent<Game_Input>(); 
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
