using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassroomMove : MonoBehaviour
{
    // The build index of the scene to load.
    public int sceneBuildIndex;

    // Called when another collider enters this GameObject's trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");

        // Check if the collider belongs to the player.
        if(other.CompareTag("Player"))
        {
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            Scene activeScene = SceneManager.GetActiveScene();
            Debug.Log("Current Active Scene: " + activeScene.name);
        }
    }
}

