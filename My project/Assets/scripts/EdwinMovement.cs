using UnityEngine;
using UnityEngine.SceneManagement;

public class EdwinMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] public FixedJoystick dynamicJoystick;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveEdwin();
    }

    void FixedUpdate()
    {
        if(!gameState.gamePaused){
            moveEdwin();
        }
    }

    void moveEdwin(){
        /*
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        */
        float moveHori = dynamicJoystick.Horizontal;
        Debug.Log("x " + moveHori);

        animator.SetFloat("xmovement", moveHori);
        animator.SetBool("xmove", (moveHori != 0.0));
        float moveVert = dynamicJoystick.Vertical;
        animator.SetFloat("ymovement", moveVert);
        animator.SetBool("ymove", (moveVert != 0.0));
        animator.SetBool("Ismoving", ((moveHori != 0.0) || (moveVert != 0.0)));
        Debug.Log("y " + moveVert);
        transform.Translate(new Vector3((int) moveHori * speed * Time.deltaTime, (int) moveVert * speed * Time.deltaTime, 0f));
    }
}
