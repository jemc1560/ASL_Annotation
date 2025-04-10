using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class onswitch : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Camera.main.rect = new Rect(0, 0, 1, 1);

        var brain = Camera.main.GetComponent<Unity.Cinemachine.CinemachineBrain>();
        if (brain != null)
        {
            Destroy(brain);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
