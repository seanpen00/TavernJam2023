using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("isDead", true);
        }

    }

    void FixedUpdate()
    {
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            if (horizontal > 0)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("isRunning", true);
            }
            else
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
                animator.SetBool("isRunning", true);
            }
        }
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }


}