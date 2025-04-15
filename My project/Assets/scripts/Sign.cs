using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox; 
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool dialogActive;

    void Start()
    {
        dialogBox.SetActive(false);
    }

    void Update()
    {
        if (dialogActive)
        {
    #if UNITY_EDITOR
            // Simulate tap with mouse in the editor
            if (Input.GetMouseButtonDown(0))
            {
                CloseDialog();
            }
    #else
            // Real touch input on phone
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                CloseDialog();
            }
    #endif
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogActive)
        {
            Debug.Log("Player in Range");
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            dialogActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left range");
            CloseDialog();
        }
    }

    private void CloseDialog()
    {
        dialogBox.SetActive(false);
        dialogActive = false;
    }
}
