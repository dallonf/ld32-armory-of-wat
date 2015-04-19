using UnityEngine;
using System.Collections;

public class TGunController : MonoBehaviour
{
    public Transform LaunchPoint1;
    public Transform LaunchPoint2;
    public GameObject BulletPrefab;

    public float CooldownTime = 0.2f;
    public AudioClip ShootSound;

    private Collider2D playerCollider;
    private AudioSource audioSource;

    private float cooldownRemaining = 0;

    public void Awake()
    {
        playerCollider = GetComponentInParent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownRemaining <= 0)
        {
            Transform launchPoint = Random.value > 0.5f ? LaunchPoint1 : LaunchPoint2;
            var bullet = (GameObject)GameObject.Instantiate(BulletPrefab, launchPoint.position, launchPoint.rotation);
            Physics2D.IgnoreCollision(playerCollider, bullet.GetComponent<Collider2D>());
            audioSource.PlayOneShot(ShootSound);
            cooldownRemaining = CooldownTime;
        }

        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }
    }
}
