using UnityEngine;

// added to gameManager as a placeholder as it actually does nothing related to it
public class pauseMenuButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject pausePanel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick(){
        gameState.togglePause();
        pausePanel.SetActive(gameState.gamePaused);
        //Debug.Log("Clicked!");
    }
}
