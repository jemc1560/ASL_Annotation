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
            // Tap on screen (touch device)
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CloseDialog();
            }

            // Press spacebar (keyboard)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CloseDialog();
            }
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
