﻿using UnityEngine;
using System.Collections;

public class BoomBotAttack : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public Color FlashColor;
    public int Flashes = 3;
    public float FlashTime = 0.3f;
    public float DetonationRange = 3;
    public float ExplosionRadius = 3;
    public float ExplosionForce = 1000;
    public int ExplosionDamage = 20;

    private SpriteRenderer spriteRenderer;
    private Transform player;

    private bool isAboutToExplode = false;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
            player = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && !isAboutToExplode)
        {
            var dist = Vector2.SqrMagnitude(transform.position - player.position);
            if (dist < DetonationRange*DetonationRange)
            {
                isAboutToExplode = true;
                StartCoroutine(Detonate());
            }
        }
    }

    private IEnumerator Detonate()
    {
        for (int i = 0; i < Flashes; i++)
        {
            spriteRenderer.color = FlashColor;
            yield return new WaitForSeconds(FlashTime);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(FlashTime);
        }
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        var caughtInExplosion = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
        foreach (var item in caughtInExplosion)
        {
            if (item != this.GetComponent<Collider2D>())
            {
                if (!item.CompareTag("Enemy"))
                {
                    item.SendMessage("TakeDamage", ExplosionDamage, SendMessageOptions.DontRequireReceiver);
                }
                var itemRigidbody = item.GetComponent<Rigidbody2D>();
                if (itemRigidbody)
                {
                    itemRigidbody.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
                    PhysicsUtil.AddExplosionForce2D(itemRigidbody, ExplosionForce, transform.position, ExplosionRadius);
                }
            }
        }
        this.SendMessage("InstaDie");
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetonationRange);
    }
}
