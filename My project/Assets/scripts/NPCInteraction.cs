using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject annotationUIPanel;
    private bool inRange = false;

    // If you want to disable the EdwinMovement script
    private EdwinMovement edwinMovement;

    void Start()
    {
        // Find the player GameObject by tag 
        GameObject edwin = GameObject.FindGameObjectWithTag("Player");
        if (edwin != null)
        {
            edwinMovement = edwin.GetComponent<EdwinMovement>();
        }
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenAnnotationUI();
        }
    }

    void OpenAnnotationUI()
    {
        annotationUIPanel.SetActive(true);

        // Disable Edwin's movement
        if (edwinMovement != null)
        {
            edwinMovement.enabled = false;
        }
    }

    public void CloseAnnotationUI()
    {
        annotationUIPanel.SetActive(false);

        // Re-enable Edwin's movement
        if (edwinMovement != null)
        {
            edwinMovement.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
