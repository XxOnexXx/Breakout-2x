using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    float moveInput;
    Rigidbody2D rb;
    //Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }

        rb.linearVelocity = Vector2.right * moveInput * moveSpeed;
    }

   
}
