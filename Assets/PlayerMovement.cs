using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    enum JumpState
    {
        ON_GROUND,
        JUMPING,
        FALLING
    }

    public float Speed = 30;
    public float Deceleration = 0.1f;
    public float MaxJumpTime = 0.25f;
    public float JumpForce = 10;

    private Rigidbody2D rigidbody2d;
    private Transform feet;
    private JumpState CurrentJumpState = JumpState.ON_GROUND;

    private float jumpTime = 0;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        feet = transform.FindChild("feet");
    }

    void FixedUpdate()
    {
        bool isOnGround = IsOnGround();
        if (isOnGround)
        {
            CurrentJumpState = JumpState.ON_GROUND;
        }
        else if (CurrentJumpState != JumpState.JUMPING)
        {
            CurrentJumpState = JumpState.FALLING;
        }

        float horizontal = Input.GetAxis("Horizontal");

        rigidbody2d.AddForce(new Vector2(horizontal * Speed, 0));

        // Decelerate for better control
        //if (isOnGround && Mathf.Approximately(horizontal, 0))
        //{
        //    rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x * -Deceleration, 0));
        //}

        bool jumpButton = Input.GetAxis("Vertical") > 0;

        if (jumpButton)
        {
            if ((CurrentJumpState == JumpState.ON_GROUND || CurrentJumpState == JumpState.JUMPING) && jumpTime < MaxJumpTime)
            {
                CurrentJumpState = JumpState.JUMPING;
                rigidbody2d.AddForce(new Vector2(0, JumpForce));
                jumpTime += Time.deltaTime;
            }
        }
        else if (CurrentJumpState == JumpState.ON_GROUND)
        {
            jumpTime = 0;
        }

        if (CurrentJumpState == JumpState.JUMPING && (jumpTime >= MaxJumpTime || !jumpButton))
        {
            CurrentJumpState = JumpState.FALLING;
        }
    }

    protected bool IsOnGround()
    {
        return Physics2D.Linecast(transform.position, feet.position);
    }
}
