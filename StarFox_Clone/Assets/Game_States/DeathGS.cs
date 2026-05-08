using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGS : Game_State
{
    [SerializeField] private GameObject deathMenu;  

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
