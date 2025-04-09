using UnityEngine;
using UnityEngine.SceneManagement;

public class onswitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Scene Loaded: " + SceneManager.GetActiveScene().name);
        Camera.main.rect = new Rect(0, 0, 1, 1);

        var brain = Camera.main.GetComponent<Unity.Cinemachine.CinemachineBrain>();
        if (brain != null)
        {
            Debug.Log("Old CinemachineBrain found — destroying.");
            Destroy(brain);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
