using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Health PlayerHealth;
    public Slider Slider;

    public void Awake()
    {
        PlayerHealth = FindObjectOfType<Health>();
        Slider = GetComponent<Slider>();
    }

    public void FixedUpdate()
    {
        if (PlayerHealth)
        {
            Slider.value = (float)PlayerHealth.CurrentHealth / PlayerHealth.MaxHealth;
        }
        else
        {
            Slider.value = 0;
        }
    }
}
