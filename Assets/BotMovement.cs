using UnityEngine;
using System.Collections;

public class BotMovement : MonoBehaviour
{
    public float Speed = 5;

    private GroundDetector groundDetector;
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        groundDetector = GetComponent<GroundDetector>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool isOnGround = groundDetector.IsOnGround();

        bool directionReversed = transform.localScale.x < 0;
        
        if (isOnGround)
        {
            var targetVelocity = new Vector2(Speed * (directionReversed ? -1 : 1), rigidbody2d.velocity.y);
            rigidbody2d.velocity = targetVelocity;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
