using UnityEngine;

public class EdwinMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] public FixedJoystick dynamicJoystick;
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
        /*
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        */
        float moveHori = dynamicJoystick.Horizontal;
        float moveVert = dynamicJoystick.Vertical;
        transform.Translate(new Vector3(moveHori * speed * Time.deltaTime, moveVert * speed * Time.deltaTime, 0f));
    }
}
