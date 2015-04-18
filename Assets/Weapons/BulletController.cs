using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public int Damage = 40;
    public float Speed = 30f;
    public float TTL = 2;

    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, TTL);
        rigidbody2d.velocity = transform.right * Speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

}
