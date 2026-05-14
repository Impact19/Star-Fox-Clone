using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement; 

public class Death_Menu_UI : MonoBehaviour
{
    public GameObject player;
    private Ship_Health shipHealth;
    [SerializeField] private Button resetButton, quitButton;
    private EventSystem eventSystem; 
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

    public void quitGame() {
        Application.Quit(); 
    }

    private void OnEnable()
    {
      //resetButton.onClick.AddListener(playButton);
    //  quitButton.onClick.AddListener(quitGame);
        
    }

    private void OnDisable()
    {
      //  resetButton.onClick.RemoveAllListeners();
      //  quitButton.onClick.RemoveAllListeners(); 
    }
}
