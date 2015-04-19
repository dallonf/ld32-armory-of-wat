using UnityEngine;
using System.Collections;

public class DamageAtVelocity : MonoBehaviour
{
    public ParticleSystem ParticleSystemWhenDamaging;
    public float MinSpeed = 4;
    public float MaxTime = 2;
    public float MaxTimeAfterCollision = 0.25f;
    public int Damage = 50;

    private float timeSinceStart = 0;
    private float timeSinceCollision = 0;
    private bool hasCollided = false;

    private bool isDamaging = false;

    private Rigidbody2D rigidbody2d;

    public void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaging)
        {
            timeSinceStart += Time.deltaTime;
            //if (hasCollided)
            //{
            //    timeSinceCollision += Time.deltaTime;
            //}

            if (timeSinceStart > MaxTime)
            {
                StopDamaging();
            }
            //else if (hasCollided && timeSinceCollision > MaxTimeAfterCollision)
            //{
            //    Debug.Log("Collision timeout");
            //    StopDamaging();
            //}
            else if (Vector2.SqrMagnitude(rigidbody2d.velocity) < MinSpeed*MinSpeed)
            {
                StopDamaging();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDamaging)
        {
            collision.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void StopDamaging()
    {
        isDamaging = false;
        ParticleSystemWhenDamaging.enableEmission = false;
    }

    public void StartDamaging()
    {
        isDamaging = true;
        ParticleSystemWhenDamaging.enableEmission = true;
        timeSinceStart = 0;
        timeSinceCollision = 0;
        hasCollided = false;
    }
}
