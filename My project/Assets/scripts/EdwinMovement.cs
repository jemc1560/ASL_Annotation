using UnityEngine;

public class EdwinMovement : MonoBehaviour
{
    float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveEdwin();
    }

    void moveEdwin(){
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveHori * speed * Time.deltaTime, moveVert * speed * Time.deltaTime, 0f));
    }
}
