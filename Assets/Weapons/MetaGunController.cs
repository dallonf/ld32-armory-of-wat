﻿using UnityEngine;
using System.Collections;

public class MetaGunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotsToFire = 3;
    public float DelayToFire = 0.5f;
    public float DelayBetweenShots = 0.25f;
    public float TimeAfterFire = 1;
    public AudioClip ShootSound;

    public Transform LaunchPoint;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        LaunchPoint = transform.FindChild("launch-point");
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        yield return new WaitForSeconds(DelayToFire);
        for (int i = 0; i < ShotsToFire; i++)
        {
            audioSource.PlayOneShot(ShootSound);
            var bullet = (GameObject)GameObject.Instantiate(BulletPrefab, LaunchPoint.position, LaunchPoint.rotation);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            
            yield return new WaitForSeconds(DelayBetweenShots);
        }
        yield return new WaitForSeconds(TimeAfterFire);
        Destroy(gameObject);
    }
}
