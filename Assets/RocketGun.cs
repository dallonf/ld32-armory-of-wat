using UnityEngine;
using System.Collections;

public class RocketGun : MonoBehaviour
{

    public float Force = 1;
    public AudioClip FireSound;
    public float MuzzleFlashTime = 0.1f;
    public float CooldownTime = 0.4f;

    private Rigidbody2D playerRigidbody;
    private AudioSource audioSource;
    private SpriteRenderer muzzleFlash;

    private float currentMuzzleFlashTime = 0;
    private float cooldownRemaining = 0;

    public void Awake()
    {
        playerRigidbody = GetComponentInParent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        muzzleFlash = transform.FindChild("muzzle-flash").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownRemaining <= 0)
        {
            audioSource.PlayOneShot(FireSound);
            playerRigidbody.AddForce(Force * transform.right * -1, ForceMode2D.Impulse);
            muzzleFlash.enabled = true;
            currentMuzzleFlashTime = MuzzleFlashTime;
            cooldownRemaining = CooldownTime;
            SendMessageUpwards("StartDamaging");
        }

        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }

        if (currentMuzzleFlashTime > 0)
        {
            currentMuzzleFlashTime -= Time.deltaTime;
            if (currentMuzzleFlashTime <= 0)
            {
                muzzleFlash.enabled = false;
            }
        }
    }
}
