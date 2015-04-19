using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public SpriteRenderer[] Sprites;
    public AudioClip HurtSound;

    private bool isInvulnerable = false;

    public int FlashTimes = 5;
    public float FlashFrequency = 0.1f;
    public float FlashAlpha = 0.5f;

    private AudioSource audioSource;

    public event System.Action OnTakeDamage;
    public event System.Action OnDie;

    // Use this for initialization
    void Awake()
    {
        CurrentHealth = MaxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvulnerable) return;
        CurrentHealth -= amount;
        if (HurtSound)
        {
            audioSource.PlayOneShot(HurtSound);
        }
        if (OnTakeDamage != null) OnTakeDamage();
        if (CurrentHealth <= 0)
        {
            InstaDie();
        }
        else
        {
            StartCoroutine(DamageFlash());
        }
    }

    IEnumerator DamageFlash()
    {
        isInvulnerable = true;
        for (int i = 0; i < FlashTimes; i++)
        {
            foreach (var sprite in Sprites)
            {
                sprite.color = new Color(1, 1, 1, FlashAlpha);
            }
            yield return new WaitForSeconds(FlashFrequency);
            foreach (var sprite in Sprites)
            {
                sprite.color = new Color(1, 1, 1, 1);
            }
            yield return new WaitForSeconds(FlashFrequency);
        }
        isInvulnerable = false;
    }

    public void InstaDie()
    {
        CurrentHealth = 0;
        if (OnDie != null) OnDie();
        Destroy(gameObject);
    }
}
