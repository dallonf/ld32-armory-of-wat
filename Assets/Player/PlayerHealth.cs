using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health;
    public SpriteRenderer[] Sprites;

    private bool isInvulnerable = false;

    public int FlashTimes = 5;
    public float FlashFrequency = 0.1f;
    public float FlashAlpha = 0.5f;

    public event System.Action OnTakeDamage;

    // Use this for initialization
    void Awake()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isInvulnerable) return;
        Health -= amount;
        if (OnTakeDamage != null) OnTakeDamage();
        if (Health <= 0)
        {
            Health = 0;
            Destroy(gameObject);
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
}
