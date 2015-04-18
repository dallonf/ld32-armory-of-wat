using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 30;
    public float Deceleration = 0.1f;
    public float MaxJumpTime = 0.25f;
    public float JumpForce = 10;

    private Rigidbody2D rigidbody2d;

    private float jumpTime = 0;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rigidbody2d.AddForce(new Vector2(horizontal * Speed, 0));

        // Decelerate for better control
        if (Mathf.Approximately(horizontal, 0))
        {
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x * -Deceleration, 0));
        }

        bool isJumping = Input.GetAxis("Vertical") > 0;

        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime < MaxJumpTime)
            {
                rigidbody2d.AddForce(new Vector2(0, JumpForce));
            }
        }
        else
        {
            jumpTime = 0;
        }
    }
}
