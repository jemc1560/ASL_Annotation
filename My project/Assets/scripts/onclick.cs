using UnityEngine;


public class onclick : MonoBehaviour
{
    private SpriteRenderer button_sprite;
    private BoxCollider2D box_collide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_sprite  = GetComponent<SpriteRenderer>();
        box_collide = button_sprite.GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            if (hit.collider != null)
            {

                if (hit.collider == box_collide)
                {
                    SceneController.entergame();
                }

            }
        }

    }
}
