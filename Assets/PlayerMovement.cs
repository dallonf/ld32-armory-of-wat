using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 30;
    public float Deceleration = 0.1f;

    private Rigidbody2D rigidbody2d;

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
            Debug.DrawRay(transform.position, rigidbody2d.velocity, Color.red);
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x * -Deceleration, 0));
        }
    }
}
