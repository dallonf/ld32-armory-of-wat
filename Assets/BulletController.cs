using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float Speed = 30f;

    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.MovePosition(transform.position + transform.right * Speed * Time.deltaTime);
    }
}
