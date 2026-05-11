using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Death_Menu_UI : MonoBehaviour
{
    public GameObject player;
    private Ship_Health shipHealth;
    [SerializeField] private 
    // Start is called before the first frame update
    void Start()
    {  

        shipHealth = player.GetComponent<Ship_Health>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void quitButton() {
        Application.Quit(); 
    }
}
