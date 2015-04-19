using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float FireDelay = 0.2f;
    public int BurstCount = 3;
    public float TimeBetweenBursts = 1;

    private Transform firePoint;

    void Awake()
    {
        firePoint = transform.FindChild("fire-point");
    }

    public void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenBursts);
            for (int i = 0; i < BurstCount; i++)
            {
                var rotation = firePoint.rotation;
                //if (transform.localScale.x < 0)
                //{
                //    rotation *= Quaternion.AngleAxis(180, Vector3.forward);
                //}
                var bullet = (GameObject)Instantiate(BulletPrefab, firePoint.position, rotation);
                
                Physics2D.IgnoreCollision(transform.parent.parent.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
            }
        }
    }

    public void FixedUpdate()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            var playerPosition = player.transform.position;
            var diff = playerPosition - firePoint.position;
            var angle = AngleMath.VectorToAngle2D(diff);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
}
