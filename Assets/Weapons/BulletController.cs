using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public int Damage = 40;
    public float Speed = 30f;
    public float TTL = 2;
    public GameObject ImpactEffect;

    public bool DamageEnemies = true;

    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, TTL);
        rigidbody2d.velocity = transform.right * Speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (DamageEnemies || !collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        }
        
        if (!collision.gameObject.CompareTag("Platform"))
        {
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

}
